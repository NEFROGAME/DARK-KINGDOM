using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerCurrency : MonoBehaviour
{
    [Header("Currency")]
    [SerializeField]
    private int currency = 0;

    [Header("UI")]
    [SerializeField]
    private Text currencyText;


    private const string CURRENCY_KEY = "PlayerCurrency";


    private void Awake()
    {
        currency =
            PlayerPrefs.GetInt(
                CURRENCY_KEY,
                0
            );

        UpdateUI();
    }


    public void AddCurrency(int amount)
    {
        if (amount <= 0)
            return;


        currency += amount;

        SaveCurrency();
        UpdateUI();


        Debug.Log(
            "💰 Currency: " +
            currency
        );
    }


    public int GetCurrency()
    {
        return currency;
    }


    private void SaveCurrency()
    {
        PlayerPrefs.SetInt(
            CURRENCY_KEY,
            currency
        );

        PlayerPrefs.Save();
    }


    private void UpdateUI()
    {
        if (currencyText != null)
        {
            currencyText.text =
                currency.ToString();
        }
    }
} // class
