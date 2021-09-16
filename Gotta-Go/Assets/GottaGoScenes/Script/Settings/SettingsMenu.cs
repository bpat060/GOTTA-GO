using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    //variables for setting menu, currently only sound
    public AudioMixer audioMixer;

    //method to adjust volume, player can use the slider to lower or increase volume.
    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

}