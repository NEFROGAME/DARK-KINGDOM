using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    [Header("Attack")]
    [SerializeField] 
    private float attackCooldown = 0.5f;

    [SerializeField] 
    private int damageAmount = 10;

    [SerializeField] private Vector2 attackSize = new Vector2(1.5f, 1f);

    [Header("Attack Point")]

    [SerializeField] 
    private Transform attackPoint;

    [SerializeField] 
    private float attackPointRightX = 1f;

    [SerializeField] 
    private float attackPointLeftX = -1f;

    [Header("Enemy")]
    [SerializeField] private LayerMask enemyLayer;

    [Header("Animation")]
    [SerializeField] private Animator animator;

    private SpriteRenderer spriteRenderer;
    private float nextAttackTime;

    [Header("Audio")]
    [SerializeField]
    private AudioManager audioManager;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    private void Update()
    {
        UpdateAttackPoint();

        if (Input.GetKeyDown(KeyCode.H) && Time.time >= nextAttackTime)
        {
            Attack();
        }
    }

    private void UpdateAttackPoint()
    {
        if (attackPoint == null)
            return;

        Vector3 pointPosition = attackPoint.localPosition;

        if (spriteRenderer.flipX)
        {
            // اللاعب يواجه اليسار
            pointPosition.x = attackPointLeftX;
        }
        else
        {
            // اللاعب يواجه اليمين
            pointPosition.x = attackPointRightX;
        }

        // نغير Position فقط
        attackPoint.localPosition = pointPosition;
    }

    private void Attack()
    {
        nextAttackTime = Time.time + attackCooldown;

        // تشغيل Attack Animation
        animator.SetTrigger(TagManager.ATTACK_PLAYER_TAG);

        // البحث عن الأعداء أمام اللاعب
        Collider2D[] hits = Physics2D.OverlapBoxAll(
            attackPoint.position,
            attackSize,
            0f,
            enemyLayer
        );

        foreach (Collider2D hit in hits)
        {
            EnemyHealth enemyHealth = hit.GetComponent<EnemyHealth>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damageAmount);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireCube(
            attackPoint.position,
            attackSize
        );
    }

    public void PlayAttackSound()
    {
        audioManager.PlayAttack();
    }
} // class
