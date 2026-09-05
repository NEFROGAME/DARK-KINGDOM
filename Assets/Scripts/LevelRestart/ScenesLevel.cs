using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesLevel : MonoBehaviour
{
    [Header("Victory Scene")]
    [SerializeField]
    private string victorySceneName = "VICTORY1";


    private bool levelCompleted = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // التأكد أن المتصادم هو اللاعب
        if (!collision.CompareTag(TagManager.PLAYER_TAG))
            return;


        // منع تشغيل الفوز أكثر من مرة
        if (levelCompleted)
            return;


        levelCompleted = true;


        Debug.Log(
            "🏆 Level Complete: " +
            SceneManager.GetActiveScene().name
        );


        // الانتقال إلى شاشة الفوز
        SceneManager.LoadScene(victorySceneName);
    }
}
