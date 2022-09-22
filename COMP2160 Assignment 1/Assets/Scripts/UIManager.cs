using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    static private UIManager instance;
    static public UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("There is not UIManager in the scene.");
            }
            return instance;
        }
    }

    public Text score;
    public string scoreFormat;

    public Text highestScore;
    public string highestScoreFormat;


    public GameObject gameOverPanel;
    void Awake()
    {
        if (instance != null)
        {
            // there is already a UIManager in the scene, destory this one
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        score.text = string.Format(scoreFormat, GameManager.Instance.Score);
        highestScore.text = string.Format(highestScoreFormat, PlayerPrefs.GetInt("HighestScore", 0).ToString());
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
        gameOverPanel.SetActive(false);
    }
}
