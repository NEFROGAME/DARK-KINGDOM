using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShopUI : MonoBehaviour
{
    [Header("Main Menu")]
    [SerializeField]
    private GameObject mainMenuCanvas;


    [Header("Shop")]
    [SerializeField]
    private GameObject shopPanel;


    private void Start()
    {
        // تجهيز الحالة فقط
        if (mainMenuCanvas != null)
        {
            mainMenuCanvas.SetActive(true);
        }

        if (shopPanel != null)
        {
            shopPanel.SetActive(false);
        }

        Debug.Log("🛒 ShopUI Ready");
    }


    public void OpenShop()
    {
        if (mainMenuCanvas == null)
        {
            Debug.LogError(
                "❌ Main Menu Canvas غير مربوط!"
            );

            return;
        }


        if (shopPanel == null)
        {
            Debug.LogError(
                "❌ Shop Panel غير مربوط!"
            );

            return;
        }


        mainMenuCanvas.SetActive(false);
        shopPanel.SetActive(true);


        Debug.Log("🛒 SHOP OPEN");
    }


    public void CloseShop()
    {
        if (mainMenuCanvas == null)
        {
            Debug.LogError(
                "❌ Main Menu Canvas غير مربوط!"
            );

            return;
        }


        if (shopPanel == null)
        {
            Debug.LogError(
                "❌ Shop Panel غير مربوط!"
            );

            return;
        }


        shopPanel.SetActive(false);
        mainMenuCanvas.SetActive(true);


        Debug.Log("🛒 SHOP CLOSE");
    }
}
