using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenuScript : MonoBehaviour
{

    public AudioMixer audioMixer;
    
    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("VolumeParam", volume);
    }
    

    public void setQuality (int index)
    {
        QualitySettings.SetQualityLevel(index);
    }
}
