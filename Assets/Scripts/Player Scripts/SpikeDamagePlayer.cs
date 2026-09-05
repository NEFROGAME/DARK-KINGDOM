using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDamagePlayer : MonoBehaviour
{
    [SerializeField]
    private int damageAmount = 3;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag(TagManager.PLAYER_TAG))
            return;

        PlayerHealth playerHealth =
            collision.gameObject.GetComponentInParent<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damageAmount);
        }
    }
}
