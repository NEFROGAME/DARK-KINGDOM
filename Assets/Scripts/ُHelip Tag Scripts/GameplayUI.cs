using UnityEngine;
using UnityEngine.UI;

public class GameplayUI : MonoBehaviour
{
    [Header("Player")]
    [SerializeField]
    private PlayerCurrency playerCurrency;

    [SerializeField]
    private PlayerStars playerStars;

    [SerializeField]
    private PlayerHealth playerHealth;


    [Header("UI Text")]
    [SerializeField]
    private Text currencyText;

    [SerializeField]
    private Text starsText;

    [SerializeField]
    private Text healthText;


    private void Update()
    {
        UpdateCurrencyUI();
        UpdateStarsUI();
        UpdateHealthUI();
    }


    private void UpdateCurrencyUI()
    {
        int currency = playerCurrency.GetCurrency();

        currencyText.text = "💰 " + currency;
    }


    private void UpdateStarsUI()
    {
        int stars = playerStars.GetStars();

        starsText.text = "⭐ " + stars + "/3";
    }


    private void UpdateHealthUI()
    {
        int health = playerHealth.GetCurrentHealth();

        healthText.text =
            "❤️ " + health + "/" +
            playerHealth.GetMaxHealth();
    }
} // End of file
