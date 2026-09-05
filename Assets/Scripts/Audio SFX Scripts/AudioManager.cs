using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // مصدر تشغيل الأصوات
    private AudioSource audioSource;


    [Header("Player / Enemy SFX")]

    // صوت القفز
    [SerializeField]
    private AudioClip jumpClip;

    // صوت الهجوم
    [SerializeField]
    private AudioClip attackClip;

    // صوت الإصابة
    //[SerializeField]
    //private AudioClip hitClip;

    // صوت الموت
    [SerializeField]
    private AudioClip deathClip;

    // صوت الركض
    [SerializeField]
    private AudioClip RunClip;


    [Header("Collect SFX")]

    // صوت جمع العملة
    [SerializeField]
    private AudioClip collectCoinClip;

    // صوت جمع النجمة
    [SerializeField]
    private AudioClip collectStarClip;


    [Header("Door SFX")]

    // صوت فتح الباب
    [SerializeField]
    private AudioClip doorOpenClip;


    [Header("UI SFX")]

    // صوت الضغط على الأزرار
    [SerializeField]
    private AudioClip buttonClickClip;


    // الحصول على AudioSource
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }


    // صوت القفز
    public void PlayJump()
    {
        audioSource.PlayOneShot(jumpClip);
    }


    // صوت الهجوم
    public void PlayAttack()
    {
        audioSource.PlayOneShot(attackClip);
    }


    // صوت الإصابة
    /*
    public void PlayHit()
    {
        audioSource.PlayOneShot(hitClip);
    }
    */


    // صوت الموت
    public void PlayDeath()
    {
        audioSource.PlayOneShot(deathClip);
    }


    // صوت الركض
    public void PlayRun()
    {
        audioSource.PlayOneShot(RunClip);
    }


    // صوت جمع العملة
    public void PlayCollectCoin()
    {
        audioSource.PlayOneShot(collectCoinClip);
    }


    // صوت جمع النجمة
    public void PlayCollectStar()
    {
        audioSource.PlayOneShot(collectStarClip);
    }


    // صوت فتح الباب
    public void PlayDoorOpen()
    {
        audioSource.PlayOneShot(doorOpenClip);
    }


    // صوت الضغط على أزرار الواجهة
    public void PlayButtonClick()
    {
        audioSource.PlayOneShot(buttonClickClip);
    }

} // class
