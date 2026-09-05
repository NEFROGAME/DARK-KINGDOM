using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    public static VFXManager Instance;

    [Header("Player VFX")]
    [SerializeField]
    private ParticleSystem bloodVFX;


    private void Awake()
    {
        // Singleton
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }


    public void PlayBloodVFX(Vector3 position)
    {
        if (bloodVFX == null)
        {
            Debug.LogError(
                "❌ Blood VFX غير مربوط في VFXManager!"
            );

            return;
        }


        Instantiate(
            bloodVFX,
            position,
            Quaternion.identity
        );
    }
}
