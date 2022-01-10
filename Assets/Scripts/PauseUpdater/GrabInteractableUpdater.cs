using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabInteractableUpdater : MonoBehaviour
{

    private XRGrabInteractable interactable;

    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<XRGrabInteractable>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.deltaTime == 0f) {
            interactable.enabled = false;
        } else {
            interactable.enabled = true;
        }
    }
}
