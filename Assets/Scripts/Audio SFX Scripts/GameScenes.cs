using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameScenes : MonoBehaviour
{

    [Header("Panels")]
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject optionsPanel;


    // =========================
    // MAIN MENU
    // =========================

    // START
    public void StartGame()
    {
        SceneManager.LoadScene(TagManager.GAME_SCENE);
    }


    // OPTIONS
    public void OpenOptions()
    {
        mainMenuPanel.SetActive(false);
        optionsPanel.SetActive(true);
    }


    // BACK
    public void CloseOptions()
    {
        optionsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }


    // EXIT
    public void ExitGame()
    {
        Application.Quit();
    }


    // =========================
    // LOAD LEVEL
    // =========================

    // تحميل أي Level بالاسم
    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }


}
