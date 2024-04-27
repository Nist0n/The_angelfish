using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Serialization;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    
    [SerializeField] public AudioSource musicSource;
    [SerializeField] public AudioSource sfxSource;

    public List<AudioClip> music, sounds;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    private void Start()
    {
        PlayMusic("TownTheme");
    }

    public void PlayMusic(string soundName)
    {
        AudioClip s = music.Find(x => x.name == soundName);

        if (s != null)
        {
            musicSource.clip = s;
            musicSource.Play();
        }
    }
    
    public void PlaySFX(string soundName)
    {
        AudioClip s = sounds.Find(x => x.name == soundName);

        if (s != null)
        {
            sfxSource.PlayOneShot(s);
        }
    }
}
