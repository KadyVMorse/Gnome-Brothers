using UnityEngine.Audio;
using UnityEngine;
using System;


public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update

    public Sound[] sounds;

    public static AudioManager instance;
    void Awake()
       
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        //Prevents the Audio Manager being Deleted between scenes
        DontDestroyOnLoad(gameObject);
         foreach (Sound s in sounds)
        {
            //buttons and slides for the audio so it can be adjusted
           s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

     void Start()
    {
        //plays the theme contnuisly
        Play("Theme");
       
    }

    //if song name is wrong in Audio Manager then it will display this messege
    public void Play( string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound:" + name + "not found!");
            return;

        }

           
        s.source.Play();
    }
}
