using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using Cinemachine;

public class ZoomTransition : MonoBehaviour
{
    [SerializeField] private Volume pp; // urp post processing
    private LensDistortion lensDistortion;
    private Vignette vignette;

    [SerializeField] private ParticleSystem ps;

    [SerializeField] private CinemachineVirtualCamera cm, cmZoom;

    public bool ZoomActive;
    public float zoomSpeed;

    private void Start()
    {
        pp.profile.TryGet(out lensDistortion);
        pp.profile.TryGet(out vignette);
    }

    private void Update()
    {
        if (ZoomActive)
        {
            cm.gameObject.SetActive(false);
            cmZoom.gameObject.SetActive(true);

            ps.gameObject.SetActive(true);
            lensDistortion.intensity.value = Mathf.Lerp(lensDistortion.intensity.value, -0.5f, zoomSpeed * Time.deltaTime);
            vignette.intensity.value = Mathf.Lerp(vignette.intensity.value, 0.5f, zoomSpeed * Time.deltaTime);
        }
    }
}
