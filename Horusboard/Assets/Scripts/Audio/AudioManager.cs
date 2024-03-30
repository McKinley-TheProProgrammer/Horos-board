using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] 
    private List<Sound> sounds;

    private readonly Dictionary<string, Sound> soundDict = new Dictionary<string, Sound>();
    
    protected override void Awake()
    {
        base.Awake();
        
        foreach (var sound in sounds)
        {
            sound.audioSource = gameObject.AddComponent<AudioSource>();
            
            sound.audioSource.clip = sound.audioClip;
            sound.audioSource.volume = sound.volume;
            sound.audioSource.pitch = sound.pitch;
            sound.audioSource.loop = sound.loop;
            sound.audioSource.playOnAwake = false;
            
            soundDict.Add(sound.name,sound);
            Debug.Log(soundDict.Count);
        }
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        foreach (var sound in sounds)
        {
            Stop(sound);
        }
    }

    private Sound GetSound(string soundName)
    {
        if (!soundDict.TryGetValue(soundName, out Sound sound))
        {
            Debug.LogError($"Sound {soundName} not found in the Dictionary");
            return null;
        }

        return sound;
    }
    public void Play(Sound sound)
    {
        Sound soundToPlay = GetSound(sound.name);
        if (soundToPlay == null)
        {
            return;
        }
        soundToPlay.audioSource.Play();
    }

    public void Stop(Sound sound)
    {
        Sound soundToPlay = GetSound(sound.name);
        if (soundToPlay == null)
        {
            return;
        }
        soundToPlay.audioSource.Stop();
    }
}
