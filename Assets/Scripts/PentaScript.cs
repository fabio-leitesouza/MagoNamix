using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PentaScript : MonoBehaviour
{
    public GameObject Player;
    public GameObject TextPortal;
    private AudioSource audioSource;
    public AudioClip portalSound;
    public int TotalCollections = 8;
    
    // Update is called once per frame

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }
    void Update()
    {
        PlayerController playerScript = Player.GetComponent<PlayerController>();
        
        if (playerScript.Collections >= TotalCollections)
        {
            GetComponent<Animator>().SetBool("PentaOn", true);          
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController playerScript = Player.GetComponent<PlayerController>();
        if (other.gameObject.CompareTag("Player") && playerScript.Collections >= TotalCollections)
        {            
            TextPortal.SetActive(true);
            Time.timeScale = 0;
            audioSource.PlayOneShot(portalSound);
            SceneManager.LoadScene("game2");
        }
    }
}
