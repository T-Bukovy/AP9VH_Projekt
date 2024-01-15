using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinalScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Vysledne skore = " + PointCollector.globalScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
