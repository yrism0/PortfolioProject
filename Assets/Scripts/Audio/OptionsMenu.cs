using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{// Sam Speirs - Options Menu Script - Audio control split into two scripts which isn't ideal

    public AudioMixer audioMixer;

    public AudioMixerGroup musicVolumeMixer;
    public Slider musicSlider;

    public void SetVolume(float volume)
    {
        // Meant to control Master Volume, although I believe it is controlled through the audio control script now
        // I don't wanna delete this incase it messes something up though
        audioMixer.SetFloat("MasterVolume", volume);
    }

    public void SetMusicVolume(float musicVolume)
    {
        // Allows for adjusting Music Volume
        musicVolumeMixer.audioMixer.SetFloat("SFXvolume", musicSlider.value);
    }

}
