using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using Cinemachine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class ComicReverse : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private CinemachineVirtualCamera cm;
    [SerializeField] private VideoPlayer panel;
    [SerializeField] private Animator transition;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource rewindSound;
    [SerializeField] private Volume pp; // urp post processing
    [SerializeField] private GameObject button;
    [SerializeField] private SoundFadeManager soundFadeManager;
    [SerializeField] private GameObject instructionText;

    // Post Processing
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

    [Space(5)]
    [Header("Passive Chromatic Abberation")]
    [SerializeField] private float chromMaxPassive;
    [SerializeField] private float passiveSpeed;

    private bool isRewinding = false;
    private float timer;

    private void Start()
    {
        timer = 0;
        panel.playbackSpeed = 0;

        instructionText.SetActive(true);

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
        if (isRewinding) // applies post processing changes, eventually fades out
        {
            panel.playbackSpeed = Mathf.Lerp(panel.playbackSpeed, 1, (transitionTime * 3) * Time.deltaTime);

            chromaticAberration.intensity.value = Mathf.Lerp(chromaticAberration.intensity.value, chromMax, transitionTime * Time.deltaTime);
            bloom.intensity.value = Mathf.Lerp(bloom.intensity.value, bloomMax, transitionTime * Time.deltaTime);
            colorAdjustments.hueShift.value = Mathf.Lerp(colorAdjustments.hueShift.value, colorMax, transitionTime * Time.deltaTime);
            lensDistortion.intensity.value = Mathf.Lerp(lensDistortion.intensity.value, distortionAmount, transitionTime * Time.deltaTime);

            timer += Time.deltaTime;

            if (timer > 1.5)
                soundFadeManager.FadeAudio();

            if (timer > 3)
                transition.SetTrigger("Start");

            if (timer > 4)
                SceneManager.LoadScene(5);
        }

        if (!isRewinding) // constantly changes chromatic abberation values
            chromaticAberration.intensity.value = Mathf.PingPong(passiveSpeed * Time.time, chromMaxPassive) + 0.2f;

        if (cm.isActiveAndEnabled && Input.GetKeyDown(KeyCode.LeftShift) && !isRewinding) // limits the activation to only once per load
        {
            instructionText.SetActive(false);
            button.SetActive(false);
            if (!rewindSound.isPlaying)
                rewindSound.Play();
            audioSource.pitch = -1;
            isRewinding = true;
        }
    }
}
