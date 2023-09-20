using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicController : MonoBehaviour
{
    public GameObject Magic;
    public GameObject Staff ;
    public AudioClip ShootingSound; // Audio de disparo
    // Start is called before the first frame update
    
    void Update()
    {
        if (Input.GetButtonDown ("Fire1"))
        {
            Instantiate(Magic, Staff.transform.position, Staff.transform.rotation);
            //AudioController.instance.PlayOneShot(ShootingSound); // Toca o som de tiro
        }
    }
}
