using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovemant : MonoBehaviour
{

    [Header("Movement")]
    [SerializeField]
    private float moveSpeed = 5f;

    [SerializeField]
    private float jumpForce = 5f;


    [Header("Components")]
    private Rigidbody2D myBody;
    private Animator animator;
    private SpriteRenderer spriteRenderer;


    [Header("Audio")]
    [SerializeField]
    private AudioManager audioManager;


    private float moveInput;
    private bool isGround;


    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void Update()
    {
        ReadMovementInput();
        Flip();
        Anim();
        Jump();
    }


    private void FixedUpdate()
    {
        Move();
    }


    private void ReadMovementInput()
    {
        moveInput = Input.GetAxisRaw(TagManager.AXIS_HORIZONTAL);
    }


    private void Move()
    {
        myBody.velocity = new Vector2(
            moveInput * moveSpeed,
            myBody.velocity.y
        );
    }


    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            myBody.velocity = new Vector2(
                myBody.velocity.x,
                jumpForce
            );

            animator.SetBool(
                TagManager.JUMP_TAG,
                true
            );

            audioManager.PlayJump();
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer ==
            LayerMask.NameToLayer(TagManager.GROUND_TAG))
        {
            isGround = true;

            animator.SetBool(
                TagManager.JUMP_TAG,
                false
            );
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer ==
            LayerMask.NameToLayer(TagManager.GROUND_TAG))
        {
            isGround = false;
        }
    }


    private void Anim()
    {
        bool isRunning = moveInput != 0;

        animator.SetBool(
            TagManager.RUN_TAG,
            isRunning
        );
    }


    private void Flip()
    {
        if (moveInput > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (moveInput < 0)
        {
            spriteRenderer.flipX = true;
        }
    }


    // يتم استدعاؤها من Run Animation Event
    public void PlayRun()
    {
        audioManager.PlayRun();
    }
} // class
