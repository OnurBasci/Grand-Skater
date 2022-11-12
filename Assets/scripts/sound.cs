using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class sound
{
    public string name;
    public AudioClip Clip;

    [Range(0f, 1f)]
    public float volume;
    [Range(0.1f, 3f)]
    public float pitch;
    [Range(0f, 1.1f)]
    public float ses_uzaklik; 

    public bool loop;

    [HideInInspector]
    public AudioSource source;

    public AudioMixerGroup mixer;
}
