using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour
{
    private AudioSource audioSource; // Componente de áudio
    public static AudioControl instance; // Singleton
    // Awake é chamado antes do Start
    void Awake()
    {
        audioSource = GetComponent<AudioSource>(); // Pega o componente de áudio
        instance = this; // Singleton
    }
    public void PlayOneShot(AudioClip sound)
    {
        audioSource.PlayOneShot(sound); // Toca o som
    }  
}
