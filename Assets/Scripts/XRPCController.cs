using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class XRPCController : MonoBehaviour
{

    public TrackedPoseDriver targetTracker;

    public InputActionProperty pcPositionInput;
    public InputActionProperty pcRotationInput;

    public InputActionProperty devicePositionInput;
    public InputActionProperty deviceRotationInput;

    // Start is called before the first frame update
    void Start()
    {
        if(!XRSettings.isDeviceActive)
        {
            Debug.Log("No headset is plugged");
        }
        else if(XRSettings.isDeviceActive && XRSettings.loadedDeviceName == "MockHMD Display")
        {
            targetTracker.positionInput = pcPositionInput;
            targetTracker.rotationInput = pcRotationInput;
            Debug.Log("PC keyboard and mouse are plugged");
        }
        else
        {
            targetTracker.positionInput = devicePositionInput;
            targetTracker.rotationInput = deviceRotationInput;
            transform.GetChild(0).gameObject.SetActive(false);
            Debug.Log("Headset is plugged");
        }
    }

}
