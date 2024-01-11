using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PointCollector : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    public static int globalScore = 0;
    public static int levelScore = 0;
    // Start is called before the first frame update

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Perla"))
        {
            Destroy(collision.gameObject);
            levelScore++;
            scoreText.text = "Skore: " + levelScore;
        }

    
    }



    void Start()
    {
        scoreText.text = "Score: " + levelScore;
    }

    
}
