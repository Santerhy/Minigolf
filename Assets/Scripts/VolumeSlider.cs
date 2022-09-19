using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public string volumeParameter = "MasterVolume";
    public AudioMixer mixer;
    public Slider slider;
    public float multiplier;

    private void Awake()
    {
        slider.onValueChanged.AddListener(VolumeSliderChanged);
    }

    public void VolumeSliderChanged(float value)
    {
        mixer.SetFloat(volumeParameter, Mathf.Log10(value) * multiplier);
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat(volumeParameter, slider.value);
    }

    // Start is called before the first frame update
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat(volumeParameter, 0.8f);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
