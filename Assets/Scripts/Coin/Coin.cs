using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    [Header("Currency")]
    [SerializeField]
    private int value = 1;


    [Header("Audio")]
    [SerializeField]
    private AudioManager audioManager;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerCurrency playerCurrency =
            collision.GetComponent<PlayerCurrency>();


        if (playerCurrency != null)
        {
            playerCurrency.AddCurrency(value);

            audioManager.PlayCollectCoin();

            Destroy(gameObject);
        }
    }


} // class










