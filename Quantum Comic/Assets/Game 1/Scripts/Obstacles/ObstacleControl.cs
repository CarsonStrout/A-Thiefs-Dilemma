using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleControl : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private WaveParticle waveParticle;
    private BoxCollider obsCollider;
    [SerializeField] private Renderer[] myModels;
    [SerializeField] private Material[] materials;

    private void Start()
    {
        obsCollider = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        // turns off colliders and changes material when player is in wave mode, back on when not
        if (waveParticle.inWave)
        {
            obsCollider.enabled = false;
            for (int i = 0; i < myModels.Length; i++)
            {
                myModels[i].material = materials[1];
            }
        }
        else
        {
            obsCollider.enabled = true;
            for (int i = 0; i < myModels.Length; i++)
            {
                myModels[i].material = materials[0];
            }
        }

    }
}
