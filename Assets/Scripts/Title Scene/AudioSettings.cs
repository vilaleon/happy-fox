using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private Slider SFXVolumeSlider;

    void Start()
    {
        float volume;
        audioMixer.GetFloat("MusicVolume", out volume);
        musicVolumeSlider.value = volume;
        audioMixer.GetFloat("SFXVolume", out volume);
        SFXVolumeSlider.value = volume;
    }

    public void changeMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", volume);
    }

    public void changeSFXVolume(float volume)
    {
        audioMixer.SetFloat("SFXVolume", volume);
    }
}
