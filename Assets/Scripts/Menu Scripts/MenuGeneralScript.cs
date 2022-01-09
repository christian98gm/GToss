﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGeneralScript : MonoBehaviour
{
   
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
