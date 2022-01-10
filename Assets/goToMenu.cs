using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class goToMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnButtonPress()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
