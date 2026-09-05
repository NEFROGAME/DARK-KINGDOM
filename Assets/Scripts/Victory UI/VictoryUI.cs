using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class VictoryUI : MonoBehaviour
{
    [Header("UI")]
    [SerializeField]
    private Text levelText;

    [SerializeField]
    private Text currencyText;

    [SerializeField]
    private Text starsText;


    [Header("Level Result")]
    [SerializeField]
    private int levelNumber = 1;

    [SerializeField]
    private int collectedCurrency = 20;

    [SerializeField]
    private int collectedStars = 3;


    [Header("Next Level")]
    [SerializeField]
    private string nextLevelName = "Level2";


    private bool victoryShown = false;


    private void Awake()
    {
      

        Time.timeScale = 1f;
    }


    public void ShowVictory()
    {
        // منع ظهور شاشة الفوز أكثر من مرة
        if (victoryShown)
            return;

        victoryShown = true;


        // تحديث معلومات الفوز
        ShowResult();
    }


    private void ShowResult()
    {
        if (levelText != null)
        {
            levelText.text =
                "LEVEL " +
                levelNumber +
                " COMPLETE";
        }


        if (currencyText != null)
        {
            currencyText.text =
                "COINS  " +
                collectedCurrency;
        }


        if (starsText != null)
        {
            starsText.text =
                "STARS  " +
                collectedStars +
                " / 3";
        }
    }


    public void Continue()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(nextLevelName);
    }


    public void MainMenu()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("MainMenu");
    }
}
