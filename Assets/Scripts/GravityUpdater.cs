using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GravityUpdater : MonoBehaviour
{

    public TextMeshProUGUI textUI;

    public void GravityUpdate(float value)
    {
        textUI.text = value.ToString("F2");
        Physics.gravity = new Vector3(0.0f, value, 0.0f);
    }
}
