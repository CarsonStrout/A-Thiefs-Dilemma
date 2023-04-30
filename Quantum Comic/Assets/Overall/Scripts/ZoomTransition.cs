using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using Cinemachine;
using UnityEngine.SceneManagement;

public class ZoomTransition : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Volume pp; // urp post processing
    [SerializeField] private ParticleSystem ps;
    [SerializeField] private CinemachineVirtualCamera cm, cmZoom;
    [SerializeField] private Animator transition;


    private LensDistortion lensDistortion;
    private Vignette vignette;
    [Space(5)]
    [SerializeField] private float distortionAmount = -0.5f;

    [Space(5)]
    [SerializeField] private bool zoomActive = false;
    [SerializeField] private float zoomSpeed;

    [Space(5)]
    [SerializeField] private int levelToLoad;

    private void Start()
    {
        pp.profile.TryGet(out lensDistortion);
        pp.profile.TryGet(out vignette);
    }

    private void Update()
    {
        if (zoomActive)
        {
            StartCoroutine(ZoomLoad(levelToLoad));
        }
    }

    public void activeZoom()
    {
        zoomActive = true;
    }

    IEnumerator ZoomLoad(int levelIndex)
    {
        // zoom effects
        cm.gameObject.SetActive(false);
        cmZoom.gameObject.SetActive(true);

        ps.gameObject.SetActive(true);
        lensDistortion.intensity.value = Mathf.Lerp(lensDistortion.intensity.value, distortionAmount, zoomSpeed * Time.deltaTime);
        vignette.intensity.value = Mathf.Lerp(vignette.intensity.value, 0.5f, zoomSpeed * Time.deltaTime);

        // wait
        yield return new WaitForSeconds(0.5f);

        // crossfade animation
        transition.SetTrigger("Start");

        // wait
        yield return new WaitForSeconds(1);

        // load scene
        SceneManager.LoadScene(levelIndex);

        PlayerPrefs.SetInt("PageNumber", 0);
    }
}
