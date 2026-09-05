using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangingSaw : MonoBehaviour
{
    [Header("Swing")]
    [SerializeField]
    private float swingAngle = 45f;

    [SerializeField]
    private float swingSpeed = 1f;


    private Rigidbody2D rb;

    private float startRotationZ;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        startRotationZ = rb.rotation;
    }


    private void FixedUpdate()
    {
        SwingAxe();
    }


    private void SwingAxe()
    {
        float angle =
            Mathf.Sin(Time.time * swingSpeed)
            * swingAngle;

        rb.MoveRotation(
            startRotationZ + angle
        );
    }
}
