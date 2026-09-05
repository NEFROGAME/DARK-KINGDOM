using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] private int maxHealth = 1;

    private int currentHealth;
    private ParticleSystem blood;

    private void Awake()
    {
        currentHealth = maxHealth;

        blood = GetComponentInChildren<ParticleSystem>(true);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (blood == null)
            return;

        blood.gameObject.SetActive(true);

        blood.Stop(
            true,
            ParticleSystemStopBehavior.StopEmittingAndClear
        );

        blood.Play();

        Destroy(gameObject, 0.1f);
    }
} // class
