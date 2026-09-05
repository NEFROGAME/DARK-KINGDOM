using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    [Header("Audio Manager")]
    [SerializeField]
    private AudioManager audioManager;


    // صوت الضغط على الزر
    public void PlayClickSound()
    {
        if (audioManager == null)
        {
            Debug.LogWarning("AudioManager غير مربوط في ButtonSound.");
            return;
        }

        audioManager.PlayButtonClick();
    }
}
