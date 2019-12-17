using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //when you hit the button play it will load the first level of the game
public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    // will quit the game when you hit quit
    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

}
