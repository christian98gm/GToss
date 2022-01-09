using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGeneralScript : MonoBehaviour
{

    public void RestartMap()
    {
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
    }

    public void PlayEarthScene ()
    {
        SceneManager.LoadScene("Tierra");
    }
}
