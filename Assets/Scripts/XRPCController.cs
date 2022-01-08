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

    private bool isPC = true;
    private bool deviceOn = false;
    private UnityEngine.XR.InputDevice device;
    
    private InputDeviceCharacteristics deviceChars = InputDeviceCharacteristics.Left
        | InputDeviceCharacteristics.Controller;


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
            isPC = false;
        }
    }

    void Update() {
        LinkMenuController();
        CheckMenuRequest();
    }

    private void LinkMenuController() {
        if(!isPC && !deviceOn) {
            List<UnityEngine.XR.InputDevice> devices = new List<UnityEngine.XR.InputDevice>();
            InputDevices.GetDevicesWithCharacteristics(deviceChars, devices);
            if(devices.Count > 0) {
                device = devices[0];
                deviceOn = true;
            }
        }
    }

    private void CheckMenuRequest() {
        if(isPC) {
            if(Keyboard.current.mKey.wasPressedThisFrame) {
                DoMenuStuff();
            }
        } else {
            if(device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.menuButton, out bool buttonPressed) && buttonPressed) {
                DoMenuStuff();
            }
        }
    }

    private void DoMenuStuff() {
        Debug.Log("Menu open");
    }
}
