using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStars : MonoBehaviour
{
    [Header("Stars")]
    [SerializeField]
    private int stars = 0;

    private const int MaxStars = 3;


    public int GetStars()
    {
        return stars;
    }


    public void AddStar()
    {
        if (stars >= MaxStars)
        {
            return;
        }

        stars++;
    }

} // class
