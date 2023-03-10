using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleControl : MonoBehaviour
{
    public WaveParticle waveParticle;
    private BoxCollider obsCollider;
    [SerializeField] private Renderer[] myModels;
    private Color[] colors;

    private void Start()
    {
        obsCollider = GetComponent<BoxCollider>();

        colors = new Color[myModels.Length];

        for (int i = 0; i < myModels.Length; i++)
        {
            colors[i] = myModels[i].material.color;
        }

    }

    private void Update()
    {
        if (waveParticle.inWave)
        {
            obsCollider.enabled = false;
            for (int i = 0; i < myModels.Length; i++)
            {
                colors[i].a = 0.25f;
                myModels[i].material.color = colors[i];
            }
        }
        else
        {
            obsCollider.enabled = true;
            for (int i = 0; i < myModels.Length; i++)
            {
                colors[i].a = 1f;
                myModels[i].material.color = colors[i];
            }
        }

    }
}
