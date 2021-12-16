using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Simulation;

public class XRPCController : MonoBehaviour
{

    public TrackedPoseDriver targetTracker;
    public List<GameObject> controllers;
    private XRDeviceSimulator deviceSimulator;

    public InputActionProperty pcPositionInput;
    public InputActionProperty pcRotationInput;

    public InputActionProperty devicePositionInput;
    public InputActionProperty deviceRotationInput;

    private bool isPC = false;
    private bool firstTime = true;

    // Start is called before the first frame update
    void Start()
    {
        deviceSimulator = GetComponentInChildren<XRDeviceSimulator>();
        if(!XRSettings.isDeviceActive)
        {
            Debug.Log("No headset is plugged");
        }
        else if(XRSettings.isDeviceActive && XRSettings.loadedDeviceName == "MockHMD Display")
        {
            targetTracker.positionInput = pcPositionInput;
            targetTracker.rotationInput = pcRotationInput;
            isPC = true;
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

    void Update()
    {
        if(firstTime)
        {
            firstTime = false;
            if(isPC)
            {
                for(int i = 0; i < controllers.Count; i++)
                {
                    HandController hc = controllers[i].GetComponentInChildren<HandController>();
                    if(hc != null) {
                        hc.SetPCMode(deviceSimulator, i == 0 ? deviceSimulator.manipulateLeftAction : deviceSimulator.manipulateRightAction);
                    }
                }
            }
        }
    }

}