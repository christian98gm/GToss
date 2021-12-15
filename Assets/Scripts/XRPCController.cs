using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class XRPCController : MonoBehaviour
{

    public TrackedPoseDriver target;

    public InputActionProperty pcPositionInput;
    public InputActionProperty pcRotationInput;

    public InputActionProperty devicePositionInput;
    public InputActionProperty deviceRotationInput;

    // Start is called before the first frame update
    void Start() {
        if(!XRSettings.isDeviceActive) {
            Debug.Log("No headset is plugged");
        } else if(XRSettings.isDeviceActive && XRSettings.loadedDeviceName == "MockHMD Display") {
            target.positionInput = pcPositionInput;
            target.rotationInput = pcRotationInput;
            Debug.Log("PC keyboard and mouse are plugged");
        } else {
            target.positionInput = devicePositionInput;
            target.rotationInput = deviceRotationInput;
            Debug.Log("Headset is plugged");
        }
    }

}
