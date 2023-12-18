using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingMenu : MonoBehaviour
{
    
    public AudioMixer AudioMixer;
    
    public void SetVolume (float volume)
    {
        AudioMixer.SetFloat("volume1", volume);
    }
}
