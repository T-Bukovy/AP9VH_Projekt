using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioSource finished;
    void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            finished.Play();
            CompleteLevel();
        }
    }

    private void CompleteLevel()
    {
        PointCollector.globalScore = PointCollector.levelScore;
        Debug.Log("Loading next level...");
        if(SceneManager.GetActiveScene().buildIndex + 1 == SceneManager.sceneCountInBuildSettings-1) //Nutno upravit na poslední ID sceny 
        {
            DestroyDontDestroyOnLoadObjects();
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void DestroyDontDestroyOnLoadObjects()
    {
        KeepMeAlivve[] keepAliveObjects = FindObjectsOfType<KeepMeAlivve>();
        foreach (KeepMeAlivve keepAliveObject in keepAliveObjects)
        {
            // Destroy the game objects that were marked with DontDestroyOnLoad
            Destroy(keepAliveObject.gameObject);
        }
    }
}
