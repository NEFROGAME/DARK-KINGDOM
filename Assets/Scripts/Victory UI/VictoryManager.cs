using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VictoryManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField]
    private Text levelText;

    [SerializeField]
    private Text currencyText;

    [SerializeField]
    private Text starsText;


    [Header("Next Level")]
    [SerializeField]
    private string nextLevelName = "Level2";


    private void Start()
    {
        ShowVictoryData();
    }


    private void ShowVictoryData()
    {
        int level =
            PlayerPrefs.GetInt(
                "VictoryLevel",
                1
            );


        int currency =
            PlayerPrefs.GetInt(
                "VictoryCurrency",
                0
            );


        int stars =
            PlayerPrefs.GetInt(
                "VictoryStars",
                0
            );


        if (levelText != null)
        {
            levelText.text =
                "LEVEL " +
                level +
                " COMPLETE";
        }


        if (currencyText != null)
        {
            currencyText.text =
                "COINS " +
                currency;
        }


        if (starsText != null)
        {
            starsText.text =
                "STARS " +
                stars +
                " / 3";
        }
    }


    public void Continue()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(
            nextLevelName
        );
    }


    public void MainMenu()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(
            "MainMenu"
        );
    }
}