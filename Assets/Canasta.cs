using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Canasta : MonoBehaviour
{

    public Button nextLevelButton;
    public Button goToMenuButton;
    // Start is called before the first frame update
    void Start()
    {
        nextLevelButton = GameObject.FindGameObjectWithTag("ButtonNextLevel").GetComponent<Button>();
        goToMenuButton = GameObject.FindGameObjectWithTag("ButtonGoToMenu").GetComponent<Button>();
        void OnTriggerEnter(Collider collision)
        {
            if(collision.tag == "Player") //Puede ser "pelota" o lo que sea que pongais como tag
            {
                //nextLevelButton.enable = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
