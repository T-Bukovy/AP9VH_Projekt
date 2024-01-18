using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class FinalScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI bestScore;
    // Start is called before the first frame update
    void Start()
    {
        if (PointCollector.globalScore > PlayerPrefs.GetInt("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", PointCollector.globalScore);
        }

        bestScore.text = "Best score = " + PlayerPrefs.GetInt("BestScore");
        scoreText.text = "Final score = " + PointCollector.globalScore;

    }

    // Update is called once per frame

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        PointCollector.globalScore = 0;
        PointCollector.levelScore = 0;
        SceneManager.LoadScene(0);

    }
}
