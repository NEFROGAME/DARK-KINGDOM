using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAudioManger : MonoBehaviour
{
    // صوت تحويم الماوس فوق الزر
    [SerializeField]
    private AudioClip buttonHoverClip;

    // صوت الضغط على الزر
    [SerializeField]
    private AudioClip buttonClickClip;

    // صوت تأكيد الاختيار
    [SerializeField]
    private AudioClip buttonConfirmClip;

    // صوت الرجوع
    [SerializeField]
    private AudioClip buttonBackClip;


    // مصدر تشغيل الأصوات
    private AudioSource audioSource;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }


    // =========================
    // Main Menu SFX
    // =========================

    // تشغيل صوت Hover
    public void PlayButtonHover()
    {
        audioSource.PlayOneShot(buttonHoverClip);
    }


    // تشغيل صوت Click
    public void PlayButtonClick()
    {
        audioSource.PlayOneShot(buttonClickClip);
    }


    // تشغيل صوت Confirm
    public void PlayButtonConfirm()
    {
        audioSource.PlayOneShot(buttonConfirmClip);
    }


    // تشغيل صوت Back
    public void PlayButtonBack()
    {
        audioSource.PlayOneShot(buttonBackClip);
    }
}
