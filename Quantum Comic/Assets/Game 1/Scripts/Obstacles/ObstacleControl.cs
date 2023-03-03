using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleControl : MonoBehaviour
{
    public WaveParticle waveParticle;
    private BoxCollider obsCollider;
    [SerializeField] private Renderer myModel;
    private Color color;

    private void Start()
    {
        obsCollider = GetComponent<BoxCollider>();
        color = myModel.material.color;
    }

    private void Update()
    {
        if (waveParticle.inWave)
        {
            obsCollider.enabled = false;
            color.a = 0.5f;
        }
        else
        {
            obsCollider.enabled = true;
            color.a = 1f;
        }

        myModel.material.color = color;
    }
}
