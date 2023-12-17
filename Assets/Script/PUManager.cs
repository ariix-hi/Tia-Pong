using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PUManager : MonoBehaviour
{
    public Transform spawnArea;
    public int maxPowerUpAmount;
    public int spawnInterval;
    public float spawnTimeLimit;
    public Vector2 powerUpAreaMin;
    public Vector2 powerUpAreaMax;
    public List<GameObject> powerUpTemplateList;
    private List<GameObject> powerUpList;
    private Dictionary<GameObject, float> powerUpCreationTimes;
    private float timer;

    private void Start()
    {
        powerUpList = new List<GameObject>();
        powerUpCreationTimes = new Dictionary<GameObject, float>();
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnInterval)
        {
            GenerateRandomPowerUp();
            timer -= spawnInterval;
        }

        CheckAndDestroyPowerUps();
    }

    private void CheckAndDestroyPowerUps()
    {
        List<GameObject> powerUpsToRemove = new List<GameObject>();

        foreach (var powerUp in powerUpCreationTimes.Keys)
        {
            if (Time.time - powerUpCreationTimes[powerUp] >= spawnTimeLimit)
            {
                powerUpsToRemove.Add(powerUp);
            }
        }

        foreach (var powerUpToRemove in powerUpsToRemove)
        {
            RemovePowerUp(powerUpToRemove);
        }
    }

    public void GenerateRandomPowerUp()
    {
        GenerateRandomPowerUp(new Vector2(UnityEngine.Random.Range(powerUpAreaMin.x, powerUpAreaMax.x), UnityEngine.Random.Range(powerUpAreaMin.y, powerUpAreaMax.y)));
    }

    public void GenerateRandomPowerUp(Vector2 position)
    {
        Debug.Log("Test");

        if (powerUpList.Count >= maxPowerUpAmount)
        {
            return;
        }
        if (position.x < powerUpAreaMin.x ||
            position.x > powerUpAreaMax.x ||
            position.y < powerUpAreaMin.y ||
            position.y > powerUpAreaMax.y)
        {
            return;
        }

        int randomIndex = UnityEngine.Random.Range(0, powerUpTemplateList.Count);

        GameObject powerUp = Instantiate(powerUpTemplateList[randomIndex], new Vector3(position.x, position.y, powerUpTemplateList[randomIndex].transform.position.z), quaternion.identity, spawnArea);
        powerUp.SetActive(true);

        powerUpList.Add(powerUp);
        powerUpCreationTimes.Add(powerUp, Time.time); // Store creation time
    }

    public void RemovePowerUp(GameObject powerUp)
    {
        powerUpList.Remove(powerUp);
        powerUpCreationTimes.Remove(powerUp);
        Destroy(powerUp);
    }

    public void RemoveAllPowerUp()
    {
        foreach (var powerUp in powerUpList)
        {
            Destroy(powerUp);
        }

        powerUpList.Clear();
        powerUpCreationTimes.Clear();
    }
}
