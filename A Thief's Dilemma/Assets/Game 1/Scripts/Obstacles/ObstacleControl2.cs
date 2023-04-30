using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleControl2 : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private WaveParticle waveParticle;
    private MeshCollider meshCollider;

    private void Start()
    {
        meshCollider = GetComponent<MeshCollider>();
    }

    private void Update()
    {
        // turns off colliders for secret room
        if (waveParticle.inWave)
        {
            meshCollider.enabled = false;
        }
        else
        {
            meshCollider.enabled = true;
        }

    }
}
