using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class DoorOpen : MonoBehaviour
{
    [Header("Required Stars")]
    [SerializeField]
    private int requiredStars = 3;


    [Header("Door Animation")]
    [SerializeField]
    private Animator animator;


    [Header("Door UI")]
    [SerializeField]
    private GameObject doorUI;

    [SerializeField]
    private Text doorText;


    [Header("Audio")]
    [SerializeField]
    private AudioManager audioManager;


    [Header("Victory Scene")]
    [SerializeField]
    private string victorySceneName = "VICTORY1";


    private PlayerStars playerStars;
    private PlayerCurrency playerCurrency;

    private bool playerInside = false;
    private bool doorOpened = false;


    private void Start()
    {
        // إخفاء UI الباب عند بداية المرحلة
        if (doorUI != null)
        {
            doorUI.SetActive(false);
        }
    }


    private void Update()
    {
        // لا يوجد لاعب داخل منطقة الباب
        if (!playerInside)
            return;


        // الباب مفتوح بالفعل
        if (doorOpened)
            return;


        // لا يوجد PlayerStars
        if (playerStars == null)
            return;


        int stars = playerStars.GetStars();


        // اللاعب لم يجمع النجوم المطلوبة
        if (stars < requiredStars)
        {
            if (doorText != null)
            {
                doorText.text =
                    "Collect " +
                    requiredStars +
                    " Stars to Open";
            }

            return;
        }


        // اللاعب جمع النجوم المطلوبة
        OpenDoor();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // التأكد أن الجسم هو اللاعب
        if (!collision.CompareTag(TagManager.PLAYER_TAG))
            return;


        // الحصول على PlayerStars
        playerStars =
            collision.GetComponent<PlayerStars>();


        // الحصول على PlayerCurrency
        playerCurrency =
            collision.GetComponent<PlayerCurrency>();


        // التأكد من وجود PlayerStars
        if (playerStars == null)
        {
            Debug.LogError(
                "❌ PlayerStars is missing from Player!"
            );

            return;
        }


        playerInside = true;


        // إظهار UI الباب
        if (doorUI != null)
        {
            doorUI.SetActive(true);
        }


        // قراءة النجوم
        int stars = playerStars.GetStars();


        if (stars < requiredStars)
        {
            if (doorText != null)
            {
                doorText.text =
                    "Collect " +
                    requiredStars +
                    " Stars to Open";
            }
        }
        else
        {
            OpenDoor();
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        // التأكد أن الجسم هو اللاعب
        if (!collision.CompareTag(TagManager.PLAYER_TAG))
            return;


        playerInside = false;

        playerStars = null;
        playerCurrency = null;


        // إخفاء UI الباب
        if (doorUI != null)
        {
            doorUI.SetActive(false);
        }
    }


    private void OpenDoor()
    {
        // منع فتح الباب أكثر من مرة
        if (doorOpened)
            return;


        doorOpened = true;


        // تغيير نص الباب
        if (doorText != null)
        {
            doorText.text = "Door Open!";
        }


        // 🚪 تشغيل Animation الباب
        if (animator != null)
        {
            animator.SetTrigger(
                TagManager.OPEN_DOOR_TAG
            );
        }


        // 🔊 تشغيل صوت الباب
        if (audioManager != null)
        {
            audioManager.PlayDoorOpen();
        }


        // 💾 حفظ بيانات الفوز
        SaveVictoryData();


        // 🏆 الانتقال إلى شاشة الفوز
        LoadVictoryScene();
    }


    private void SaveVictoryData()
    {
        int stars = 0;
        int currency = 0;


        // الحصول على عدد النجوم
        if (playerStars != null)
        {
            stars =
                playerStars.GetStars();
        }


        // الحصول على العملات
        if (playerCurrency != null)
        {
            currency =
                playerCurrency.GetCurrency();
        }


        // حفظ رقم المرحلة
        PlayerPrefs.SetInt(
            "VictoryLevel",
            SceneManager.GetActiveScene().buildIndex
        );


        // حفظ العملات
        PlayerPrefs.SetInt(
            "VictoryCurrency",
            currency
        );


        // حفظ النجوم
        PlayerPrefs.SetInt(
            "VictoryStars",
            stars
        );


        // حفظ البيانات
        PlayerPrefs.Save();


        Debug.Log(
            "🏆 Victory Data Saved\n" +
            "Level: " +
            SceneManager.GetActiveScene().name +
            "\nStars: " +
            stars +
            "\nCurrency: " +
            currency
        );
    }


    private void LoadVictoryScene()
    {
        // التأكد من كتابة اسم Scene
        if (string.IsNullOrWhiteSpace(victorySceneName))
        {
            Debug.LogError(
                "❌ Victory Scene Name is empty!"
            );

            return;
        }


        Debug.Log(
            "🏆 Loading Victory Scene: " +
            victorySceneName
        );


        // تحميل شاشة الفوز
        SceneManager.LoadScene(
            victorySceneName
        );
    }
} // class
