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
    public float pitch;

}
public class AudioManager : Singleton<AudioManager>
{
    public List<Sound> sounds = new List<Sound>();
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
