using System;
using UnityEngine;
using UnityEngine.UIElements;

public class VolumeSlider : MonoBehaviour
{
    private Slider _slider;

    private void Awake()
    {
        _slider = gameObject.GetComponent<Slider>();
        _slider.value = Mathf.Clamp(0, PlayerPrefs.GetFloat("volume", 50), 100);
    }

    public void SetVolume(float newVolume)
    {
        PlayerPrefs.SetFloat("volume", Mathf.Clamp(0, newVolume, 100));
    }
}