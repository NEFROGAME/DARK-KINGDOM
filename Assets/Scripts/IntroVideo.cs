using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class IntroVideo : MonoBehaviour
{
    [Header("Video")]
    [SerializeField] private VideoPlayer videoPlayer;

    [Header("UI")]
    [SerializeField] private RawImage videoImage;

    [Header("Scene")]
    [SerializeField] private string mainMenuSceneName = "MainMenu";

    private void Start()
    {
        // تأكد من أن صورة الفيديو ظاهرة
        if (videoImage != null)
            videoImage.gameObject.SetActive(true);

        // ربط حدث نهاية الفيديو
        videoPlayer.loopPointReached += OnVideoFinished;

        // تشغيل الفيديو
        videoPlayer.Play();
    }

    private void OnVideoFinished(VideoPlayer vp)
    {
        // إلغاء الاشتراك من الحدث
        vp.loopPointReached -= OnVideoFinished;

        // الانتقال إلى القائمة الرئيسية
        SceneManager.LoadScene(mainMenuSceneName);
    }

    private void OnDestroy()
    {
        // تنظيف الأحداث لتجنب تسريب الذاكرة
        if (videoPlayer != null)
            videoPlayer.loopPointReached -= OnVideoFinished;
    }
}
