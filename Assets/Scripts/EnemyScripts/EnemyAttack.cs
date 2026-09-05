using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    [Header("Attack Settings")]

    // مقدار الضرر الذي يأخذه اللاعب
    [SerializeField] private int damageAmount = 1;

    // أقصى مسافة يستطيع العدو الهجوم منها
    [SerializeField] private float attackRange = 1.5f;

    // الوقت بين كل هجوم وهجوم
    [SerializeField] private float attackCooldown = 1f;


    [Header("References")]

    // اللاعب
    [SerializeField] private Transform player;

    // Animator الخاص بالعدو
    [SerializeField] private Animator animator;

    // صوت العدو
    [SerializeField] private EnemyAudio enemyAudio;


    [Header("Blood VFX")]

    // مؤثر الدم
    [SerializeField] private ParticleSystem bloodVFX;


    // الوقت الذي يسمح فيه بالهجوم القادم
    private float nextAttackTime;


    private void Start()
    {
        // البحث عن اللاعب تلقائيًا
        FindPlayer();

        // إذا لم يتم ربط Animator يدويًا
        // نحصل عليه من نفس العدو
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

        // إذا لم يتم ربط EnemyAudio يدويًا
        // نحصل عليه من نفس العدو
        if (enemyAudio == null)
        {
            enemyAudio = GetComponent<EnemyAudio>();
        }
    }


    private void Update()
    {
        // إذا لم نجد اللاعب
        // نحاول البحث عنه مرة أخرى
        if (player == null)
        {
            FindPlayer();
            return;
        }


        // حساب المسافة بين العدو واللاعب
        float distance = Vector2.Distance(
            transform.position,
            player.position
        );


        // إذا اللاعب داخل مدى الهجوم
        // وإذا انتهى وقت الانتظار
        if (distance <= attackRange &&
            Time.time >= nextAttackTime)
        {
            StartAttack();
        }
    }


    private void FindPlayer()
    {
        // البحث عن اللاعب عن طريق Tag
        GameObject playerObject =
            GameObject.FindGameObjectWithTag("Player");


        // إذا وجد اللاعب
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }


    private void StartAttack()
    {
        // تحديد موعد الهجوم القادم
        nextAttackTime =
            Time.time + attackCooldown;


        // تشغيل Animation الهجوم
        if (animator != null)
        {
            animator.SetTrigger("Attack");
        }
    }


    // =====================================================
    // هذه الدالة يتم استدعاؤها من Animation Event
    // =====================================================

    public void DealDamage()
    {
        // التأكد من وجود اللاعب
        if (player == null)
            return;


        // حساب المسافة مرة أخرى
        float distance = Vector2.Distance(
            transform.position,
            player.position
        );


        // إذا اللاعب ابتعد قبل لحظة الضربة
        // لا نعطيه ضرر
        if (distance > attackRange)
            return;


        // الحصول على PlayerHealth
        PlayerHealth playerHealth =
            player.GetComponent<PlayerHealth>();


        // إذا لم نجد PlayerHealth
        if (playerHealth == null)
            return;


        // إعطاء الضرر للاعب
        playerHealth.TakeDamage(damageAmount);


        // تشغيل مؤثر الدم
        PlayBloodVFX();


        // تشغيل صوت الهجوم
        if (enemyAudio != null)
        {
            enemyAudio.PlayAttack();
        }
    }


    private void PlayBloodVFX()
    {
        // إذا لم يوجد VFX
        if (bloodVFX == null)
            return;


        // إنشاء نسخة من مؤثر الدم عند اللاعب
        ParticleSystem blood =
            Instantiate(
                bloodVFX,
                player.position,
                Quaternion.identity
            );


        // حذف المؤثر بعد انتهائه
        Destroy(
            blood.gameObject,
            blood.main.duration +
            blood.main.startLifetime.constantMax
        );
    }


    // رسم دائرة الهجوم في Scene
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(
            transform.position,
            attackRange
        );
    }
} // class






