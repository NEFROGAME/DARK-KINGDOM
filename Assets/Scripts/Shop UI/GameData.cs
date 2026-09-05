using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameData : MonoBehaviour
{
    public static GameData Instance;


    private int currency;
    private int hearts;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }


        Instance = this;

        DontDestroyOnLoad(gameObject);


        currency =
            PlayerPrefs.GetInt("Currency", 0);

        hearts =
            PlayerPrefs.GetInt("Hearts", 1);
    }


    public int GetCurrency()
    {
        return currency;
    }


    public int GetHearts()
    {
        return hearts;
    }


    public void AddCurrency(int amount)
    {
        currency += amount;

        Save();
    }


    public bool BuyHeart()
    {
        if (hearts >= 5)
        {
            Debug.Log("❤️ وصلت للحد الأقصى 5!");
            return false;
        }


        int price = GetHeartPrice();


        if (currency < price)
        {
            Debug.Log("❌ العملات غير كافية!");
            return false;
        }


        currency -= price;

        hearts++;


        Save();


        Debug.Log(
            "❤️ تم شراء قلب: " +
            hearts
        );


        return true;
    }


    public int GetHeartPrice()
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

            default:
                return 0;
        }
    }


    private void Save()
    {
        PlayerPrefs.SetInt(
            "Currency",
            currency
        );

        PlayerPrefs.SetInt(
            "Hearts",
            hearts
        );

        PlayerPrefs.Save();
    }
}
