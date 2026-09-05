using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VictoryStats : MonoBehaviour
{
    [Header("UI")]
    [SerializeField]
    private Text levelText;

    [SerializeField]
    private Text coinsText;

    [SerializeField]
    private Text starsText;


    [Header("Level")]
    [SerializeField]
    private int levelNumber = 1;

    [SerializeField]
    private int totalCoins = 20;

    [SerializeField]
    private int totalStars = 3;


    private int collectedCoins;
    private int collectedStars;


    private void Start()
    {
        // قراءة العملات والنجوم التي جمعها اللاعب
        collectedCoins =
            PlayerPrefs.GetInt(
                "Level" + levelNumber + "_Coins",
                0
            );

        collectedStars =
            PlayerPrefs.GetInt(
                "Level" + levelNumber + "_Stars",
                0
            );


        UpdateUI();
    }


    private void UpdateUI()
    {
        if (levelText != null)
        {
            levelText.text =
                "LEVEL " + levelNumber + " COMPLETE";
        }


        if (coinsText != null)
        {
            coinsText.text =
                "COINS  " +
                collectedCoins +
                " / " +
                totalCoins;
        }


        if (starsText != null)
        {
            starsText.text =
                "STARS  " +
                collectedStars +
                " / " +
                totalStars;
        }
    }
}
