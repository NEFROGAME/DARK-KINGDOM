using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCollectible : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField]
    private AudioManager audioManager;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerStars playerStars =
            collision.GetComponent<PlayerStars>();


        if (playerStars != null)
        {
            // إضافة نجمة للاعب
            playerStars.AddStar();

            // تشغيل صوت جمع النجمة
            audioManager.PlayCollectStar();

            // حذف النجمة من المرحلة
            Destroy(gameObject);
        }
    }
} // class
