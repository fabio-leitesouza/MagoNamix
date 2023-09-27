using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionItem : MonoBehaviour
{
    public int value = 1;
    public InterfaceController scripInterfaceController;
    public AudioClip collectionSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().Collections += value;
            scripInterfaceController.UpdateSlidePlayerCollections();
            Destroy(gameObject);
            AudioControl.instance.PlayOneShot(collectionSound);
        }
    }
}
