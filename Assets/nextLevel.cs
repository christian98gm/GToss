using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class nextLevel : MonoBehaviour
{
    // Start is called before the first frame update
    Button button;
    void Start()
    {
        button = GetComponent<Button>();
        button.interactable = false;
    }
    
    public void OnButtonPress()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene +1);
    }
}
