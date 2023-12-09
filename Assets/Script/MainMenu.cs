using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame() 
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void BackToMain()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void OpenControls()
    {
        SceneManager.LoadSceneAsync(2);
    }
    public void OpenCredit()
    {
        SceneManager.LoadSceneAsync(3);
    }





}
