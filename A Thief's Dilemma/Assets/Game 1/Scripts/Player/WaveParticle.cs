using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class WaveParticle : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Material[] materials;
    [SerializeField] private GameObject playerObj;
    [SerializeField] private AudioSource waveSound;
    [SerializeField] private Volume pp; // urp post processing
    private LensDistortion lensDistortion;
    private ChromaticAberration chromaticAberration;
    private Bloom bloom;
    private Vignette vignette;

    [Space(5)]
    [Header("Distortion Stats")]
    [SerializeField] private float distMax;
    [SerializeField] private float chromMax;
    [SerializeField] private float bloomMax;
    [SerializeField] private float vignetteMax;
    [SerializeField] private float waveTime;

    [Space(5)]
    public bool inWave;

    private void Start()
    {
        //playerObj.GetComponent<SkinnedMeshRenderer>().materials[0] = materials[0];
        //playerObj.GetComponent<SkinnedMeshRenderer>().materials[1] = materials[1];

        //glasses.GetComponent<MeshRenderer>().material = materials[0];
        inWave = false;

        // gets access to post processing effects
        pp.profile.TryGet(out lensDistortion);
        pp.profile.TryGet(out chromaticAberration);
        pp.profile.TryGet(out bloom);
        pp.profile.TryGet(out vignette);
    }

    private void Update()
    {
        Material[] currentlyAssignedMaterials = playerObj.GetComponent<SkinnedMeshRenderer>().materials;

        if (Input.GetKey(KeyCode.LeftShift)) // player wave form
        {
            if (!waveSound.isPlaying)
                waveSound.Play();

            // changes player materials to use wave shaders
            //playerObj.GetComponent<SkinnedMeshRenderer>().materials[0] = materials[2];
            //glasses.GetComponent<MeshRenderer>().material = materials[3];

            currentlyAssignedMaterials[0] = materials[2];
            currentlyAssignedMaterials[1] = materials[2];

            inWave = true;

            // distorts the post processing over the stated time
            lensDistortion.intensity.value = Mathf.Lerp(lensDistortion.intensity.value, distMax, waveTime * Time.deltaTime);
            chromaticAberration.intensity.value = Mathf.Lerp(chromaticAberration.intensity.value, chromMax, waveTime * Time.deltaTime);
            bloom.intensity.value = Mathf.Lerp(bloom.intensity.value, bloomMax, waveTime * Time.deltaTime);
            vignette.intensity.value = Mathf.Lerp(vignette.intensity.value, vignetteMax, waveTime * Time.deltaTime);
        }
        else // player particle form
        {
            waveSound.Stop();

            // changes player materials to use its normal materials
            /*  playerObj.GetComponent<SkinnedMeshRenderer>().materials[0] = materials[0];
             playerObj.GetComponent<SkinnedMeshRenderer>().materials[1] = materials[1]; */

            currentlyAssignedMaterials[0] = materials[0];
            currentlyAssignedMaterials[1] = materials[1];

            inWave = false;

            // returns the post processing to its normal values over the stated time
            lensDistortion.intensity.value = Mathf.Lerp(lensDistortion.intensity.value, 0, waveTime * Time.deltaTime);
            chromaticAberration.intensity.value = Mathf.Lerp(chromaticAberration.intensity.value, 0.1f, waveTime * Time.deltaTime);
            bloom.intensity.value = Mathf.Lerp(bloom.intensity.value, 0.2f, waveTime * Time.deltaTime);
            vignette.intensity.value = Mathf.Lerp(vignette.intensity.value, 0.3f, waveTime * Time.deltaTime);
        }

        playerObj.GetComponent<SkinnedMeshRenderer>().materials = currentlyAssignedMaterials;
    }
}
