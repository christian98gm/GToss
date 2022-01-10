using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class menuController : MonoBehaviour 
{
    public Canvas menuCanvas;
    public void RestartMap()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void NextLevel()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene + 1);
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    
    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            menuCanvas.GetComponent<Canvas>().enabled = true;
        }

    }
}  