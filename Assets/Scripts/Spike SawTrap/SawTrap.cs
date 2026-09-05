using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawTrap : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField]
    private Transform pointA;

    [SerializeField]
    private Transform pointB;

    [SerializeField]
    private float moveSpeed = 2f;


    [Header("Rotation")]
    [SerializeField]
    private float rotationSpeed = 180f;


    private void Update()
    {
        MoveSaw();
        RotateSaw();
    }


    private void MoveSaw()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            pointB.position,
            moveSpeed * Time.deltaTime
        );

        if (Vector3.Distance(transform.position, pointB.position) < 0.01f)
        {
            Transform temp = pointA;
            pointA = pointB;
            pointB = temp;
        }
    }


    private void RotateSaw()
    {
        transform.Rotate(
            0f,
            0f,
            rotationSpeed * Time.deltaTime
        );
    }


}