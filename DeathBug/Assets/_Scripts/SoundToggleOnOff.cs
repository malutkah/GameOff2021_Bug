using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundToggleOnOff : MonoBehaviour
{
    public AudioManager audioManager;
    private AudioSource source;
    public GameObject SoundOn, SoundOff;

    private void Awake()
    {
        source = audioManager.GetComponent<AudioSource>();
    }

    private void OnMouseDown()
    {
        bool soundOn = SoundOn.activeSelf;
        if (soundOn) {
            audioManager.StopSound("Test");
            SoundOn.SetActive(false);
            SoundOff.SetActive(true);
            Debug.Log($"soundOn= {soundOn}");
        }
        else
        {
            audioManager.PlaySound("Test");
            SoundOn.SetActive(true);
            SoundOff.SetActive(false);
            Debug.Log($"soundOn= {soundOn}");
        }
        
    }
}
