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

    [SerializeField] private Sound[] sounds;

    public void PlaySound(string name)
    {
        Array.Find(sounds, sound => sound.name == name).clip.Play();
    }
}
