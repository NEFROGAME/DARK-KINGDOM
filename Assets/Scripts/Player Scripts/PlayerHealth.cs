using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health")]
    [SerializeField]
    private int maxHealth = 1;

    private int currentHealth;
    private bool isDead = false;


    [Header("Damage Effect")]
    [SerializeField]
    private ParticleSystem damageEffect;


    [Header("Level Restart")]
    [SerializeField]
    private LevelRestart levelRestart;


    private const string HEARTS_KEY = "PlayerHearts";


    private void Awake()
    {
        maxHealth = PlayerPrefs.GetInt(
            HEARTS_KEY,
            1
        );

        maxHealth = Mathf.Max(
            maxHealth,
            1
        );

        currentHealth = maxHealth;
    }


    public void TakeDamage(int damage)
    {
        if (isDead)
            return;

        if (damage <= 0)
            return;


        // إنقاص القلب
        currentHealth -= damage;

        currentHealth = Mathf.Max(
            currentHealth,
            0
        );


        Debug.Log(
            "💔 Player Health: " +
            currentHealth +
            " / " +
            maxHealth
        );


        // 🩸 تأثير الدمج/الضرر
        PlayDamageEffect();


        // إذا انتهت القلوب
        if (currentHealth <= 0)
        {
            Die();
        }
    }


    private void PlayDamageEffect()
    {
        if (damageEffect == null)
            return;


        Instantiate(
            damageEffect,
            transform.position,
            Quaternion.identity
        );
    }


    private void Die()
    {
        if (isDead)
            return;

        isDead = true;

        Debug.Log("💀 PLAYER DEAD");


        // إعادة نفس المستوى
        if (levelRestart != null)
        {
            levelRestart.RestartLevel();
        }
        else
        {
            Debug.LogError(
                "❌ LevelRestart غير مربوط في Inspector!"
            );
        }


        // تدمير اللاعب
        Destroy(gameObject);
    }


    public int GetCurrentHealth()
    {
        return currentHealth;
    }


    public int GetMaxHealth()
    {
        return maxHealth;
    }
} // class
