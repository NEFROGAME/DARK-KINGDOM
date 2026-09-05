using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawTrapEffects : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private Transform player;
    [SerializeField] private float activationDistance = 5f;

    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip sawLoopClip;

    [Header("Visual Effect")]
    [SerializeField] private ParticleSystem sawEffect;

    private void Start()
    {
        // لا نشغل الصوت والمؤثر عند بداية اللعبة
        if (audioSource != null)
        {
            audioSource.loop = true;
            audioSource.clip = sawLoopClip;
        }

        if (sawEffect != null)
        {
            sawEffect.Stop();
        }
    }

    private void Update()
    {
        if (player == null)
            return;

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= activationDistance)
        {
            ActivateEffects();
        }
        else
        {
            DeactivateEffects();
        }
    }

    private void ActivateEffects()
    {
        // تشغيل الصوت
        if (audioSource != null &&
            sawLoopClip != null &&
            !audioSource.isPlaying)
        {
            audioSource.Play();
        }

        // تشغيل المؤثر البصري
        if (sawEffect != null &&
            !sawEffect.isPlaying)
        {
            sawEffect.Play();
        }
    }

    private void DeactivateEffects()
    {
        // إيقاف الصوت
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }

        // إيقاف المؤثر
        if (sawEffect != null && sawEffect.isPlaying)
        {
            sawEffect.Stop();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, activationDistance);
    }
} 
