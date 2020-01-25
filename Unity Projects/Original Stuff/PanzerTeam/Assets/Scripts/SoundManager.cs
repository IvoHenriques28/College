using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public AudioMixer MasterMixer;

    public Slider musicSlider;
    public Slider masterSlider;
    


    public void SetMusicSound(float soundLevel)
    {
        soundLevel = musicSlider.value;
        MasterMixer.SetFloat("musicVol", soundLevel);
    }
    public void SetMasterSound(float soundLevel)
    {
        soundLevel = masterSlider.value;
        MasterMixer.SetFloat("masterVol", soundLevel);
    }
}
