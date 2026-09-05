using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryLevel : MonoBehaviour
{
    [Header("Victory UI")]
    [SerializeField]
    private VictoryUI victoryUI;


    private bool hasWon = false;


    private void OnTriggerEnter2D(Collider2D other)
    {
        // التأكد أن الجسم هو اللاعب
        if (!other.CompareTag(TagManager.PLAYER_TAG))
            return;


        // منع الفوز أكثر من مرة
        if (hasWon)
            return;


        hasWon = true;


        // إظهار شاشة الفوز
        if (victoryUI != null)
        {
            victoryUI.ShowVictory();
        }
        else
        {
            Debug.LogError(
                "❌ VictoryUI غير مربوط في Inspector!"
            );
        }
    }
}
