using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using TMPro;

public class FinalRoom : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private CinemachineVirtualCamera cm;
    [SerializeField] private Animator transition;
    [SerializeField] private Animator textAnimation;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource rewindSound;
    [SerializeField] private Volume pp; // urp post processing
    [SerializeField] private RewindTime rewindTime;
    [SerializeField] private SoundFadeManager soundFadeManager;
    [SerializeField] private TMP_Text endText;
    [SerializeField] private TMP_Text instructionText;

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
    [SerializeField] private float textFadeSpeed;
    private float textTimer = 0;
    private float rewindTimer = 0;
    private bool isRewinding = false;
    private bool readyToRewind = false;

    private void Start()
    {
        // gets access to post processing effects
        pp.profile.TryGet(out chromaticAberration);
        pp.profile.TryGet(out bloom);
        pp.profile.TryGet(out colorAdjustments);
        pp.profile.TryGet(out lensDistortion);
    }

    private void Update()
    {
        if (cm.isActiveAndEnabled)
        {
            if (rewindTime.enabled)
                rewindTime.enabled = false;

            if (isRewinding) // applies post processing changes, eventually fades out
            {
                instructionText.alpha = Mathf.Lerp(instructionText.alpha, 0, textFadeSpeed * Time.deltaTime);

                chromaticAberration.intensity.value = Mathf.Lerp(chromaticAberration.intensity.value, chromMax, transitionTime * Time.deltaTime);
                bloom.intensity.value = Mathf.Lerp(bloom.intensity.value, bloomMax, transitionTime * Time.deltaTime);
                bloom.scatter.value =
                colorAdjustments.hueShift.value = Mathf.Lerp(colorAdjustments.hueShift.value, colorMax, transitionTime * Time.deltaTime);
                lensDistortion.intensity.value = Mathf.Lerp(lensDistortion.intensity.value, distortionAmount, transitionTime * Time.deltaTime);

                rewindTimer += Time.deltaTime;

                if (rewindTimer > 3.5)
                    soundFadeManager.FadeAudio();

                if (rewindTimer > 5)
                    transition.SetTrigger("Start");

                InitialLoad.started = false;

                if (rewindTimer > 6)
                    SceneManager.LoadScene(0);
            }
            else if (Input.GetKeyDown(KeyCode.LeftShift) && readyToRewind && !isRewinding)
            {
                if (!rewindSound.isPlaying)
                    rewindSound.Play();
                audioSource.pitch = -1;
                isRewinding = true;
            }
            else
            {
                textTimer += Time.deltaTime;
                if (textTimer > 5)
                    textAnimation.SetTrigger("Start");

                if (textTimer > 9 && textTimer < 13)
                    endText.text = "This stopwatch is powerful...";
                if (textTimer > 13 && textTimer < 17)
                    endText.text = "But I'm losing my mind";
                if (textTimer > 17 && textTimer < 21)
                    endText.text = "This isn't the future I want";
                if (textTimer > 21 && textTimer < 25)
                    endText.text = "I may be free...";
                if (textTimer > 25 && textTimer < 29)
                    endText.text = "But the cost is too great";

                if (textTimer > 32)
                {
                    instructionText.alpha = Mathf.Lerp(instructionText.alpha, 1, textFadeSpeed * Time.deltaTime);
                    readyToRewind = true;
                }
            }
        }
    }
}
