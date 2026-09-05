using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudio : MonoBehaviour
{
    [Header("Run")]
    [SerializeField] private AudioClip runClip;

    [Header("Attack")]
    [SerializeField] private AudioClip attackClip;

    [Header("Audio Sources")]
    [SerializeField] private AudioSource runSource;
    [SerializeField] private AudioSource attackSource;

    private void Start()
    {
        PlayRun();
    }

    public void PlayRun()
    {
        if (runClip == null || runSource == null)
        {
            Debug.LogError("Run Clip or Run Source is missing!");
            return;
        }

        if (runSource.isPlaying)
            return;

        runSource.clip = runClip;
        runSource.loop = true;
        runSource.Play();

        Debug.Log("RUN SOUND STARTED");
    }

    public void StopRun()
    {
        if (runSource == null)
            return;

        runSource.Stop();

        Debug.Log("RUN SOUND STOPPED");
    }

    public void PlayAttack()
    {
        if (attackClip == null || attackSource == null)
        {
            Debug.LogError("Attack Clip or Attack Source is missing!");
            return;
        }

        attackSource.PlayOneShot(attackClip);
    }
}// class
