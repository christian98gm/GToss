using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandController : MonoBehaviour
{

    private const float TRIGGER_THRESHOLD = 0.1f;

    public GameObject controllerPrefab;
    public InputDeviceCharacteristics controllerCharacteristics;

    private InputDevice targetDevice;
    private GameObject spawnedHand;
    private Animator handAnimator;

    private bool pcMode = false;

    // Start is called before the first frame update
    void Start()
    {
        TryInitialize();
    }

    // Update is called once per frame
    void Update()
    {
        if(pcMode) {
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

        List<InputDevice> devices = new List<InputDevice>();
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
        if(targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue)) {
            handAnimator.SetFloat("Trigger", triggerValue);
        }
        else
        {
            handAnimator.SetFloat("Trigger", 0);
        }
        //Grip
        if(targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue)) {
            handAnimator.SetFloat("Grip", gripValue);
        }
        else
        {
            handAnimator.SetFloat("Grip", 0);
        }
    }

    void UpdatePCHandAnimation()
    {
        Debug.Log("PC Mode ON");
    }

    public void SetPCMode(bool mode) {
        pcMode = mode;
    }
}
