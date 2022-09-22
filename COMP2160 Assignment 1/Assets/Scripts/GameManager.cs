using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton
    static private GameManager instance;
    static public GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("There is no GameManager instance in the scene.");
            }
            return instance;
        }
    }

    private int score = 0;
    public int Score
    {
        get
        {
            return score;
        }
    }

    private int highestScore;
    
    public int HighestScore
    {
        get
        {
            return highestScore;
        }
    }


    public int scorePerCoin;

    void Awake()
    {
        if (instance != null)
        {
            // destroy duplicates
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    // add scorePerCoin to score when called
    public void ScoreCoin()
    {
        score += scorePerCoin;
    }

    public void ScoreNewHighest()
    {
        if(Score > HighestScore)
        {
            highestScore = score;
            PlayerPrefs.SetInt("HighestScore", highestScore);
        }
    }
     
    // calls UI to display when called
    public void Die()
    {
        UIManager.Instance.ShowGameOver();
        ScoreNewHighest();
    }
}
