using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class AudioManager : MonoBehaviour
{
    
    public AudioMixer audioSlider;
    public static AudioSource _hitSound;
    public static AudioClip[] _hitClip;
    public void SliderValue(float value)
    {
        audioSlider.SetFloat("MyVolume", value);
    }
}
