using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [Header("Set in Inspector")]
    public AudioMixer audioMixer;

    private Slider[] _sliders;

    private void Awake()
    {
        _sliders = GetComponentsInChildren<Slider>();
        _sliders[0].value = PlayerPrefs.GetFloat("masterVolume", 0.75f);
        _sliders[1].value = PlayerPrefs.GetFloat("musicVolume", 1f);
        _sliders[2].value = PlayerPrefs.GetFloat("sfxVolume", 1f);
    }

    public void SetVolume(String target, float newVolume)
    {
        audioMixer.SetFloat(target, Mathf.Log10(newVolume) * 20);
        PlayerPrefs.SetFloat(target, Mathf.Clamp(newVolume, 0.0001f, 1f));
    }

    public void SetMasterVolume(float newVolume)
    {
        SetVolume("masterVolume", newVolume);
    }

    public void SetMusicVolume(float newVolume)
    {
        SetVolume("musicVolume", newVolume);
    }

    public void SetSfxVolume(float newVolume)
    {
        SetVolume("sfxVolume", newVolume);
    }
}