using System;
using UnityEngine;

public class SoundToggleOnOff : MonoBehaviour
{
    public AudioManager audioManager;
    private AudioSource source;
    public GameObject SoundOn, SoundOff;
    private Sounds[] sounds;

    private void Awake()
    {
        sounds = audioManager.sounds;
    }

    private void OnMouseDown()
    {
        bool soundOn = SoundOn.activeSelf;
        if (soundOn) {
            SetVolume(0f);
            SoundOn.SetActive(false);
            SoundOff.SetActive(true);
        }
        else
        {
            SetVolume(0.25f);
            SoundOn.SetActive(true);
            SoundOff.SetActive(false);
        }
    }

    private void SetVolume(float volume)
    {
        foreach (Sounds s in sounds)
        {
            s.source.volume = volume;
        }
    }
}
