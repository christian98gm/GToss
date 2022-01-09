using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.CoreModule;

public class MenuAlGanar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindByTag(MenuAlGanar).active = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
