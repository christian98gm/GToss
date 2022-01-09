using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class HandController : MonoBehaviour
{

    public int prefabIndex = 0;
    public List<GameObject> controllerPrefabs;
    private const float speed = 0.1f;

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
        spawnedHand = Instantiate(controllerPrefabs[prefabIndex >= controllerPrefabs.Count ? 0 : Mathf.Max(prefabIndex, 0)], transform);
        handAnimator = spawnedHand.GetComponent<Animator>();
        handAnimator.updateMode = AnimatorUpdateMode.UnscaledTime;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHandAnimation();
    }

    void UpdateHandAnimation()
    {
        //Trigger
        triggerTarget = targetController.activateAction.action.ReadValue<float>();
        if(triggerCurrent != triggerTarget)
        {
           triggerCurrent = Mathf.MoveTowards(triggerCurrent, triggerTarget, speed);
           handAnimator.SetFloat("Trigger", triggerCurrent);
        }
        //handAnimator.SetFloat("Trigger", targetController.activateAction.action.ReadValue<float>());
        //Grip
        gripTarget = targetController.selectAction.action.ReadValue<float>();
        if(gripCurrent != gripTarget)
        {
           gripCurrent = Mathf.MoveTowards(gripCurrent, gripTarget, speed);
           handAnimator.SetFloat("Grip", gripCurrent);
        }
        //handAnimator.SetFloat("Grip", targetController.selectAction.action.ReadValue<float>());
    }
}
