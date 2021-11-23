using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sounds[] sounds;

    void Awake()
    {
        foreach (Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;

            s.source.loop = s.loop;
        }
    }



    public void PlaySound(string name)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " does not exist! Check for typos.");
            return;
        }

        s.source.Play();
    }
}
