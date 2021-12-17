using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Simulation;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class HandController : MonoBehaviour
{

    private const float TRIGGER_THRESHOLD = 0.1f;

    public GameObject controllerPrefab;
    public InputDeviceCharacteristics controllerCharacteristics;

    private UnityEngine.XR.InputDevice targetDevice;
    private ActionBasedController targetController;
    private GameObject spawnedHand;
    private Animator handAnimator;

    private XRDeviceSimulator deviceSimulator = null;
    private InputActionReference deviceController;

    // Start is called before the first frame update
    void Start()
    {
        targetController = GetComponentInParent<ActionBasedController>();
        TryInitialize();
    }

    // Update is called once per frame
    void Update()
    {
        if(deviceSimulator != null) {
            UpdatePCHandAnimation();
        } else {
            if(!targetDevice.isValid) {
                TryInitialize();
            } else {
                UpdateDeviceHandAnimation();
            }
        }
    }

    void TryInitialize()
    {

        List<UnityEngine.XR.InputDevice> devices = new List<UnityEngine.XR.InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);
        if(devices.Count > 0) {
            targetDevice = devices[0];
            Debug.Log(targetDevice.name);
        }

        spawnedHand = Instantiate(controllerPrefab, transform);
        handAnimator = spawnedHand.GetComponent<Animator>();

    }

    void UpdateDeviceHandAnimation()
    {
        //Trigger
        if(targetDevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.trigger, out float triggerValue)) {
            handAnimator.SetFloat("Trigger", triggerValue);
        }
        else
        {
            handAnimator.SetFloat("Trigger", 0);
        }
        //Grip
        if(targetDevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.grip, out float gripValue)) {
            handAnimator.SetFloat("Grip", gripValue);
        }
        else
        {
            handAnimator.SetFloat("Grip", 0);
        }
    }

    void UpdatePCHandAnimation()
    {
        /*//Trigger
        if(deviceController.action.ReadValue<float>() == 1) {
            handAnimator.SetFloat("Trigger", deviceSimulator.triggerAction.action.ReadValue<float>());
        }
        //Grip
        if(deviceController.action.ReadValue<float>() == 1) {
            handAnimator.SetFloat("Grip", deviceSimulator.gripAction.action.ReadValue<float>());
        }*/
        //Trigger
        handAnimator.SetFloat("Trigger", targetController.activateAction.action.ReadValue<float>());
        //Grip
        handAnimator.SetFloat("Grip", targetController.selectAction.action.ReadValue<float>());
    }

    public void SetPCMode(XRDeviceSimulator simulator, InputActionReference controller) {
        deviceSimulator = simulator;
        deviceController = controller;
    }
}
