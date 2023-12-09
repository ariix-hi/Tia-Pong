using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public int LeftScore;
    public int RightScore;
    public int maxScore;
    public BallControls ball;

    public void GameOver()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void AddRightScore(int increment)
    {    
        RightScore += increment;
        ball.ResetBall();

        if (RightScore >= maxScore)
        {
            GameOver();
        }
    }

    public void AddLeftScore(int increment)
    {
        LeftScore += increment;
        ball.ResetBall();
        
        if (LeftScore >= maxScore)
        {
            GameOver();
        }    
    }

    

    
}
