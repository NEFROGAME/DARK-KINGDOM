using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{

    [SerializeField] private float enemySpeed = 2f;

    [Header("Patrol Points")]
    [SerializeField] private Transform leftPoint;
    [SerializeField] private Transform rightPoint;

    private Rigidbody2D myBody;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        MoveEnemy();
        FlipEnemy();
    }

    private void MoveEnemy()
    {
        myBody.velocity = new Vector2(
            enemySpeed,
            myBody.velocity.y
        );

        if (transform.position.x <= leftPoint.position.x)
        {
            enemySpeed = Mathf.Abs(enemySpeed);
        }
        else if (transform.position.x >= rightPoint.position.x)
        {
            enemySpeed = -Mathf.Abs(enemySpeed);
        }
    }

    private void FlipEnemy()
    {
        if (enemySpeed > 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (enemySpeed < 0)
        {
            spriteRenderer.flipX = false;
        }
    }
} // class











