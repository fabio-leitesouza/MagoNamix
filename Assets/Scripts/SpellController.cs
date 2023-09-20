using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellController : MonoBehaviour
{
    public Transform Barrel;     // Referência ao objeto que indica o ponto de disparo
    public float fireRate = 0.5f; // Intervalo de tempo entre os disparos
    public GameObject Magic;    // Referência ao objeto que será disparado
    private float nextFire = 0.0f; // Tempo para o próximo disparo

    void Update()
    {
        HandleShooting();
    }
    private void HandleShooting()
    {
        if (Input.GetButton("Fire1") && CanShoot())
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        nextFire = Time.time + fireRate;
        Instantiate(Magic, Barrel.position, Barrel.rotation);
    }

    private bool CanShoot()
    {
        return Time.time > nextFire;
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }
}
