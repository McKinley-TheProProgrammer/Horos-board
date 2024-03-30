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