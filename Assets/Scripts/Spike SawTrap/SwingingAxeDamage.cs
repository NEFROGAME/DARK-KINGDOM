using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingingAxeDamage : MonoBehaviour
{
    [Header("Damage")]
    [SerializeField]
    private int damageAmount = 1;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag(TagManager.PLAYER_TAG))
            return;


        PlayerHealth playerHealth =
            collision.GetComponentInParent<PlayerHealth>();


        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damageAmount);
        }
    }
}
