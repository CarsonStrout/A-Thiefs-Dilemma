using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using Cinemachine;
using UnityEngine.SceneManagement;

public class ComicReverse : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private CinemachineVirtualCamera cm;
    [SerializeField] private Animator transition;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource rewindSound;
    [SerializeField] private Volume pp; // urp post processing
    [SerializeField] private GameObject button;

    private ChromaticAberration chromaticAberration;
    private Bloom bloom;
    private ColorAdjustments colorAdjustments;
    private LensDistortion lensDistortion;

    [Space(5)]
    [Header("Distortion Stats")]
    [SerializeField] private float chromMax;
    [SerializeField] private float bloomMax;
    [SerializeField] private float colorMax;
    [SerializeField] private float distortionAmount = -0.5f;
    [SerializeField] private float transitionTime;

    private bool isRewinding = false;

    private void Start()
    {
        if (rewindSound.isPlaying)
            rewindSound.Stop();

        // gets access to post processing effects
        pp.profile.TryGet(out chromaticAberration);
        pp.profile.TryGet(out bloom);
        pp.profile.TryGet(out colorAdjustments);
        pp.profile.TryGet(out lensDistortion);
    }

    private void Update()
    {
        if (cm.isActiveAndEnabled && Input.GetKeyDown(KeyCode.LeftShift) && !isRewinding)
        {
            button.SetActive(false);
            if (!rewindSound.isPlaying)
                rewindSound.Play();
            audioSource.pitch = -1;
            isRewinding = true;
            StartCoroutine(RewindToGame());
        }
    }

    IEnumerator RewindToGame()
    {
        chromaticAberration.intensity.value = Mathf.Lerp(chromaticAberration.intensity.value, chromMax, transitionTime * Time.deltaTime);
        bloom.intensity.value = Mathf.Lerp(bloom.intensity.value, bloomMax, transitionTime * Time.deltaTime);
        colorAdjustments.hueShift.value = Mathf.Lerp(colorAdjustments.hueShift.value, colorMax, transitionTime * Time.deltaTime);
        lensDistortion.intensity.value = Mathf.Lerp(lensDistortion.intensity.value, distortionAmount, transitionTime * Time.deltaTime);

        // wait
        yield return new WaitForSeconds(2f);

        // crossfade animation
        transition.SetTrigger("Start");

        // wait
        yield return new WaitForSeconds(1);

        // load scene
        SceneManager.LoadScene(5);
    }
}
