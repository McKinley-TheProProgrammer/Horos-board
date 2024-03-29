using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Sound : ScriptableObject
{
    [HideInInspector]
    public AudioSource audioSource;

    [SerializeField] 
    public AudioClip audioClip;

    [Range(0, 1f)] 
    public float volume = 1f;
    [Range(0.1f, 3f)] 
    public float pitch = 1f;

    public bool loop = false;

}
public class AudioManager : Singleton<AudioManager>
{
    [SerializeField]
    private List<Sound> sounds = new List<Sound>();

    private Dictionary<string, Sound> soundDict = new Dictionary<string, Sound>();
    
    void Start()
    {
        foreach (var sound in sounds)
        {
            sound.audioSource = gameObject.AddComponent<AudioSource>();
            
            sound.audioSource.clip = sound.audioClip;
            sound.audioSource.volume = sound.volume;
            sound.audioSource.pitch = sound.pitch;
            sound.audioSource.loop = sound.loop;
            
            soundDict.Add(sound.name,sound);
        }
    }

    private Sound GetSound(string soundName)
    {
        if (soundDict.TryGetValue(soundName, out Sound sound))
        {
            Debug.LogError($"Sound {soundName} not found in the Dictionary");
            return null;
        }

        return soundDict[soundName];
    }
    public void Play(Sound sound)
    {
        GetSound(sound.name).audioSource.Play();
    }

    public void Stop(Sound sound)
    {
        GetSound(sound.name).audioSource.Stop();
    }
}
