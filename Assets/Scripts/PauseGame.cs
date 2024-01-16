using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject pauzeMenu;
    public bool isPauzed;
    // Start is called before the first frame update
    void Start()
    {
        pauzeMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPauzed)
            {
                ResumeGame();
            }
            else
            {
                PauseMenu();
            }
        }
    }

    public void PauseMenu()
    {
        pauzeMenu.SetActive(true);
        Time.timeScale = 0f;
        isPauzed = true;
    }

    public void ResumeGame()
    {
        pauzeMenu.SetActive(false);
        Time.timeScale = 1f;
        isPauzed = false;
    }

    public void QuitTheGame()
    {
        Application.Quit();
    }
}
