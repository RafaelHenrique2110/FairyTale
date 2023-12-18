using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Volume : MonoBehaviour
{
    
    public AudioMixer AudioMixer;
    
    public void SetVolume (float volume2)
    {
        AudioMixer.SetFloat("volume1", volume2);
    }
}
