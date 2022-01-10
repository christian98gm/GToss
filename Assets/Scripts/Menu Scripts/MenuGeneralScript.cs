using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGeneralScript : MonoBehaviour
{

    public void RestartMap()
    {
        Time.timeScale = 1f;
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
    }
   
    public void ExitGame()
    {
        Application.Quit();
    }

    public void ExitToMainMenu ()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }

    public void PlayEarthScene ()
    {
        SceneManager.LoadScene("Tierra");
        Time.timeScale = 1f;
    }

    public void PlayMoonScene()
    {
        SceneManager.LoadScene("Moon");
        Time.timeScale = 1f;
    }

    public void PlayJupiterScene()
    {
        SceneManager.LoadScene("Jupiter");
        Time.timeScale = 1f;
    }
}
