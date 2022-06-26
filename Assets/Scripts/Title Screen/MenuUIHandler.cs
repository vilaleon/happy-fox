using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] private GameObject settingsView;
    [SerializeField] private GameObject defaultView;
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Slider sfxSlider;

    private bool asyncInProgress = false;

    private void Start()
    {
        float volume;
        audioMixer.GetFloat("MusicVolume", out volume);
        volumeSlider.value = volume;
        audioMixer.GetFloat("SFXVolume", out volume);
        sfxSlider.value = volume;
    }

    public async void StartGame()
    {
        if (asyncInProgress) return;
        asyncInProgress = true;
        await Task.Delay(500);
        SceneManager.LoadScene(1);
    }

    public async void Exit()
    {
        if (asyncInProgress) return;
        asyncInProgress = true;
        await Task.Delay(500);
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }

    public void ChangeView()
    {
        settingsView.SetActive(!settingsView.activeSelf);
        defaultView.SetActive(!defaultView.activeSelf);
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
