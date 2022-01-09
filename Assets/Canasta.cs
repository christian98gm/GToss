using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.CoreModule;

public class Canasta : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        void OnTriggerEnter(Collider collision)
        {
            if(collision.tag == "Player") //Puede ser "pelota" o lo que sea que pongais como tag
            {
                GameObject.FindByTag("MenuAlGanar").active = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
