using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffScript : MonoBehaviour
{
    public Transform Barrel;
    public float FireRate = 1f;
    public GameObject MagicBallPrefab;
    public AudioClip shootingSound; // O áudio que você quer reproduzir
    private AudioSource audioSource; // Componente de áudio

    private float _nextFireTime = 0f;

    private void Start()
    {
        // Obtém ou adiciona um componente AudioSource a este GameObject
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void Update()
    {
        HandleShooting();
    }

    private void HandleShooting()
    {
        if (Input.GetButton("Fire1") && Time.time >= _nextFireTime)
        {
            _nextFireTime = Time.time + FireRate;
            Instantiate(MagicBallPrefab, Barrel.position, Barrel.rotation);

            // Reproduz o som de disparo
            if (shootingSound != null)
            {
                audioSource.PlayOneShot(shootingSound);
            }
        }
    }
}
