using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDestroy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

   private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(TagManager.PLAYER_TAG))
        {
            Destroy(gameObject);
        }   
    }

}
