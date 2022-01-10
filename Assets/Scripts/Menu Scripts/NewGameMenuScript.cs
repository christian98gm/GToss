using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameMenuScript : MonoBehaviour
{
    public void playTutorial ()
    {
        SceneManager.LoadScene("Tutorial");
    }
   
}
