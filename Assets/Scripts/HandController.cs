using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class HandController : MonoBehaviour
{

    public GameObject controllerPrefab;
    private const float speed = 10.0f;

    private ActionBasedController targetController;
    private GameObject spawnedHand;
    private Animator handAnimator;

    private float gripTarget;
    private float triggerTarget;
    private float gripCurrent = 0.0f;
    private float triggerCurrent = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        targetController = GetComponentInParent<ActionBasedController>();
        spawnedHand = Instantiate(controllerPrefab, transform);
        handAnimator = spawnedHand.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHandAnimation();
    }

    void UpdateHandAnimation()
    {
        //TODO: Smooth tranasitioning
        //Trigger
        triggerTarget = targetController.activateAction.action.ReadValue<float>();
        if(triggerCurrent != triggerTarget)
        {
           triggerCurrent = Mathf.MoveTowards(triggerCurrent, triggerTarget, Time.deltaTime * speed);
           handAnimator.SetFloat("Trigger", triggerCurrent);
        }
        //handAnimator.SetFloat("Trigger", targetController.activateAction.action.ReadValue<float>());
        //Grip
        gripTarget = targetController.selectAction.action.ReadValue<float>();
        if(gripCurrent != gripTarget)
        {
           gripCurrent = Mathf.MoveTowards(gripCurrent, gripTarget, Time.deltaTime * speed);
           handAnimator.SetFloat("Grip", gripCurrent);
        }
        //handAnimator.SetFloat("Grip", targetController.selectAction.action.ReadValue<float>());
    }

    void SetGrip(float v)
    {
        gripTarget = v;
    }

    void SetTrigger(float v) {
        triggerTarget = v;
    }
}
