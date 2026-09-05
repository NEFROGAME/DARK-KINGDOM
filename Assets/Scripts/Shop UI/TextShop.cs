using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;       
public class TextShop : MonoBehaviour
{
    [Header("UI")]
    [SerializeField]
    private Text currencyText;

    [SerializeField]
    private Text heartsText;

    [SerializeField]
    private Text priceText;


    [Header("Shop Settings")]
    [SerializeField]
    private int maxHearts = 6;

    [SerializeField]
    private int basePrice = 120;


    private int currency;
    private int hearts;


    private const string CURRENCY_KEY = "PlayerCurrency";
    private const string HEARTS_KEY = "PlayerHearts";


    private void OnEnable()
    {
        LoadData();
        UpdateUI();
    }


    private void LoadData()
    {
        currency = PlayerPrefs.GetInt(
            CURRENCY_KEY,
            0
        );

        hearts = PlayerPrefs.GetInt(
            HEARTS_KEY,
            1
        );
    }


    // زر BUY
    public void BuyHeart()
    {
        // إذا وصل اللاعب إلى 6 قلوب
        if (hearts >= maxHearts)
        {
            Debug.Log("❤️ MAX 6");

            UpdateUI();

            return;
        }


        // حساب السعر
        int price = GetHeartPrice();


        // فحص العملة
        if (currency < price)
        {
            Debug.Log(
                "❌ عملة غير كافية | " +
                "لديك: " +
                currency +
                " | مطلوب: " +
                price
            );

            return;
        }


        // خصم العملة
        currency -= price;


        // إضافة قلب
        hearts++;


        // حفظ
        SaveData();


        // تحديث UI
        UpdateUI();


        Debug.Log(
            "❤️ تم شراء قلب | " +
            "Hearts: " +
            hearts +
            " / " +
            maxHearts +
            " | " +
            "Currency: " +
            currency
        );
    }


    // تحديد سعر القلب التالي
    private int GetHeartPrice()
    {
        switch (hearts)
        {
            case 1:
                return 120;

            case 2:
                return 240;

            case 3:
                return 360;

            case 4:
                return 480;

            case 5:
                return 600;

            default:
                return 0;
        }
    }


    private void SaveData()
    {
        PlayerPrefs.SetInt(
            CURRENCY_KEY,
            currency
        );

        PlayerPrefs.SetInt(
            HEARTS_KEY,
            hearts
        );

        PlayerPrefs.Save();
    }


    private void UpdateUI()
    {
        // العملة
        if (currencyText != null)
        {
            currencyText.text =
                currency.ToString();
        }


        // القلوب
        if (heartsText != null)
        {
            heartsText.text =
                hearts +
                " / " +
                maxHearts;
        }


        // السعر
        if (priceText != null)
        {
            if (hearts >= maxHearts)
            {
                priceText.text = "MAX";
            }
            else
            {
                priceText.text =
                    GetHeartPrice().ToString();
            }
        }
    }
}
