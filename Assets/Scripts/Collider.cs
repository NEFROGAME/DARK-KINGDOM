using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collider : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // التأكد أن الجسم الذي اصطدم هو اللاعب
        if (!collision.gameObject.CompareTag(TagManager.PLAYER_TAG))
            return;


        // 💀 تدمير اللاعب
        Destroy(collision.gameObject);


        // 🔄 إعادة تشغيل نفس المستوى الحالي
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().name
        );
    }
}
