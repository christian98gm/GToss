using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GravityUpdater : MonoBehaviour
{

    public TextMeshProUGUI textUI;
    public float defaultG = Physics.gravity.y;

    private void Start()
    {
        Physics.gravity = new Vector3(0.0f, defaultG, 0.0f);
    }

    public void GravityUpdate(float value)
    {
        if(textUI != null) {
            textUI.text = value.ToString("F2");
        }
        Physics.gravity = new Vector3(0.0f, value, 0.0f);
    }
}
