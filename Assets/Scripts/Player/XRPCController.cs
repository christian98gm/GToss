using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.SceneManagement;

public class XRPCController : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;

    public TrackedPoseDriver targetTracker;

    public InputActionProperty pcPositionInput;
    public InputActionProperty pcRotationInput;

    public InputActionProperty devicePositionInput;
    public InputActionProperty deviceRotationInput;

    private bool isPC = true;
    private bool deviceOn = false;
    private bool firstPress = true;
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
            if(device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.menuButton, out bool buttonPressed)) {
                if(buttonPressed && firstPress) {
                    DoMenuStuff();
                    firstPress = false;
                } else if(!buttonPressed) {
                    firstPress = true;
                }
            }
        }
    }

    private void DoMenuStuff() {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name != "MainMenu")
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
            Debug.Log("Menu open");
        }
        

    }

    private void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
}
