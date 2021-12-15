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
    void Start()
    {
        if(deviceRotationInput == null) {
            devicePositionInput = target.positionInput;
        }
        if(deviceRotationInput == null) {
            deviceRotationInput = target.rotationInput;
        }
    }

    void Update() {
        if(XRSettings.isDeviceActive && target.positionInput != devicePositionInput) {
            target.positionInput = devicePositionInput;
            target.rotationInput = deviceRotationInput;
        } else if(!XRSettings.isDeviceActive && target.positionInput != pcPositionInput) {
            target.positionInput = pcPositionInput;
            target.rotationInput = pcRotationInput;
        }
    }

}
