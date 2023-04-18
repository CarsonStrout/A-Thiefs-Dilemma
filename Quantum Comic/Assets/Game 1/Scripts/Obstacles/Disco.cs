using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Disco : MonoBehaviour
{
    [SerializeField] private Volume pp; // urp post processing
    private ColorAdjustments colorAdjustments;
    [SerializeField] private float transitionTime;
    [SerializeField] private AudioSource song;
    [SerializeField] private AudioSource ambient;

    private bool increase;

    private void Start()
    {
        // gets access to post processing effects
        pp.profile.TryGet(out colorAdjustments);
    }

    private void Update()
    {
        colorAdjustments.hueShift.value = Mathf.PingPong(Time.time * transitionTime, 180);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!song.isPlaying)
        {
            ambient.Stop();
            song.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (song.isPlaying)
        {
            song.Stop();
            ambient.Play();
        }
    }
}
