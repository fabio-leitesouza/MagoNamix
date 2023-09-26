using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionItem : MonoBehaviour
{
    public int value = 1;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Adicione o valor ao jogador.
            collision.gameObject.GetComponent<PlayerController>().Collections += value;
            Destroy(gameObject);
        }
    }
}
