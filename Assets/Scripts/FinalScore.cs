using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Vysledne skore = " + PointCollector.globalScore;
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
