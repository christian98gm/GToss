using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GravityUpdater : MonoBehaviour
{

    public Text textUI;

    public void GravityUpdate(float value)
    {
        textUI.text = "" + value;
        Physics.gravity = new Vector3(0.0f, value, 0.0f);
    }
}
