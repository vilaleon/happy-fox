using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Serializable]
    private class Sound
    {
        public string name;
        public AudioSource clip;
    }

    [SerializeField] private Sound[] ambient;
    [SerializeField] private Sound[] sounds;

    public void PlayAmbient(string name)
    {
        Array.Find(ambient, sound => sound.name == name).clip.Play();
    }

    public void StopAmbient(string name)
    {
        Array.Find(ambient, sound => sound.name == name).clip.Stop();
    }

    public void PauseAmbient(string name)
    {
        Array.Find(ambient, sound => sound.name == name).clip.Pause();
    }

    public void PlaySound(string name)
    {
        Array.Find(sounds, sound => sound.name == name).clip.Play();
    }
}
