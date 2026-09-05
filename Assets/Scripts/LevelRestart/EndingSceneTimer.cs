using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingSceneTimer : MonoBehaviour
{
    [Header("Ending Settings")]
    [SerializeField] private float waitTime = 60f;

    [Header("Next Scene")]
    [SerializeField] private string mainMenuScene = "MainMenu";

    private void Start()
    {
        StartCoroutine(LoadMainMenuAfterTime());
    }

    private IEnumerator LoadMainMenuAfterTime()
    {
        // انتظار 60 ثانية
        yield return new WaitForSeconds(waitTime);

        // الانتقال إلى القائمة الرئيسية
        SceneManager.LoadScene(mainMenuScene);
    }
}
