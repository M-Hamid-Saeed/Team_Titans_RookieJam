using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;
    public GameObject Environment1;
    public GameObject Environment2;
    public EnemySpawner enemySpawner;
    void Awake()
    {
        // to prevent Multiple instances of Audio Manager. Detail Below
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            // DontDestroyOnLoad(Environment1);
            DontDestroyOnLoad(enemySpawner.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        



    }

    private void Start()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();


            s.source.clip = s.clip;
            s.source.volume = s.volume;
           
            s.source.loop = s.loop;
            s.source.playOnAwake = s.playOnAwake;
        }
        Play("theme");
    }


    // you can call this method by the syntax => [' FindObjectOfType<AudioManager>().Play("[name of sound]"); ']
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound not found");
            return;
        }
        s.source.Play();


    }
}