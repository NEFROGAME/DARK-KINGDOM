using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Player")]
    [SerializeField]
    private Transform player;

    [Header("Camera Limits")]
    [SerializeField]
    private float minLessX;

    [SerializeField]
    private float maxManyX;

    private Vector3 moveCameraFollow;


    private void Start()
    {
        FindPlayer();
    }


    private void LateUpdate()
    {
        if (player == null)
        {
            FindPlayer();
            return;
        }


        moveCameraFollow = transform.position;


        // متابعة اللاعب X
        moveCameraFollow.x = player.position.x;


        // الحد الأدنى
        if (moveCameraFollow.x < minLessX)
        {
            moveCameraFollow.x = minLessX;
        }


        // الحد الأعلى
        if (moveCameraFollow.x > maxManyX)
        {
            moveCameraFollow.x = maxManyX;
        }


        // متابعة اللاعب Y
        moveCameraFollow.y = player.position.y;


        transform.position = moveCameraFollow;
    }


    private void FindPlayer()
    {
        GameObject playerObject =
            GameObject.FindGameObjectWithTag(TagManager.PLAYER_TAG);


        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }
} // class


