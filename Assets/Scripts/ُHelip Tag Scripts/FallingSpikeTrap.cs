using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSpikeTrap : MonoBehaviour
{
    [Header("Detection")]
    [SerializeField]
    private float detectionDistance = 5f;

    [SerializeField]
    private LayerMask playerLayer;


    [Header("Spike")]
    [SerializeField]
    private Rigidbody2D spikeRb;

    [SerializeField]
    private float gravityScale = 3f;


    [Header("Ray")]
    [SerializeField]
    private bool showRay = true;


    private bool activated;


    private void Start()
    {
        if (spikeRb == null)
        {
            Debug.LogError("FallingSpikeTrap: اربط Spike Rb في Inspector!");
            return;
        }


        // المسمار ثابت بالبداية
        spikeRb.bodyType = RigidbodyType2D.Kinematic;
        spikeRb.gravityScale = 0f;
        spikeRb.velocity = Vector2.zero;
    }


    private void Update()
    {
        DetectPlayer();

        // الخط الأحمر
        if (showRay)
        {
            Debug.DrawRay(
                transform.position,
                Vector2.down * detectionDistance,
                Color.red
            );
        }
    }


    private void DetectPlayer()
    {
        if (activated)
            return;


        RaycastHit2D hit = Physics2D.Raycast(
            transform.position,
            Vector2.down,
            detectionDistance,
            playerLayer
        );


        if (hit.collider == null)
            return;


        // هل الجسم الذي وجده الخط هو اللاعب؟
        if (!hit.collider.CompareTag(
            TagManager.PLAYER_TAG))
        {
            return;
        }


        Debug.Log("Player تم اكتشافه!");


        DropSpike();
    }


    private void DropSpike()
    {
        if (spikeRb == null)
            return;


        activated = true;


        Debug.Log("Spike Falling!");


        // السماح للمسمار بالسقوط
        spikeRb.bodyType =
            RigidbodyType2D.Dynamic;


        spikeRb.gravityScale =
            gravityScale;


        spikeRb.velocity =
            Vector2.zero;
    }
}
