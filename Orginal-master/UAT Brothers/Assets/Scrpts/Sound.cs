using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound 
{
    public string name;

    public AudioClip clip;

    // how far the volume can go up 
    [Range(0f,1f)]

   
    public float volume;

    // how far the pitchcan go up 
    [Range(.1f,3f)]
    public float pitch;

    //creates teh option to create noise on loop 
    public bool loop;

    //hides the Audio source in inspector
    [HideInInspector]
    public AudioSource source;
}
