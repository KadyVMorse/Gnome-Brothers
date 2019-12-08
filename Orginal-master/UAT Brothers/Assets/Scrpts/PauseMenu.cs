using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
  
    public GameObject PauseUI;

    private bool paused = false;

    void Start()
    {
        //This is to make sure canvas is off whle playing level
        PauseUI.SetActive(false);
    }


    void Update()
    {
        //Escape triigers pause menu 
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
        }
        // If paused then it will be on pause menu
        if (paused)
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }
        //If not paused exits pause menu 
        if (!paused)
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1;
        }
    }
    public void Resume()
    {
        //It is not paused so resumes the game 
        paused = false;
    }

    public void Restart()
    {
        //Reload to the begging of the Scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void MainMenu()
    {
        //Loads Main Menu

        SceneManager.LoadScene(0); 
    }

    public void Quit()
    {
        //Quits the game 
        Application.Quit();
    }
}

