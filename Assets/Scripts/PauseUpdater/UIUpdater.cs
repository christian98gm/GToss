using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.UI;

public class UIUpdater : MonoBehaviour
{
    
    private TrackedDeviceGraphicRaycaster raycaster;

    // Start is called before the first frame update
    void Start()
    {
        raycaster = GetComponent<TrackedDeviceGraphicRaycaster>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.deltaTime == 0f) {
            raycaster.enabled = false;
        } else {
            raycaster.enabled = true;
        }
    }
}
