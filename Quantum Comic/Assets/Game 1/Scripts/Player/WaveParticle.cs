using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class WaveParticle : MonoBehaviour
{
    public Material[] materials;
    public GameObject playerObj, glasses;
    public Volume pp;
    private LensDistortion lensDistortion;
    private ChromaticAberration chromaticAberration;
    private Bloom bloom;

    public float distMax;
    public float chromMax;
    public float bloomMax;
    public float waveTime;
    public bool inWave;

    private void Start()
    {
        playerObj.GetComponent<MeshRenderer>().material = materials[0];
        glasses.GetComponent<MeshRenderer>().material = materials[0];
        inWave = false;

        pp.profile.TryGet(out lensDistortion);
        pp.profile.TryGet(out chromaticAberration);
        pp.profile.TryGet(out bloom);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerObj.GetComponent<MeshRenderer>().material = materials[1];
            glasses.GetComponent<MeshRenderer>().material = materials[3];
            inWave = true;

            lensDistortion.intensity.value = Mathf.Lerp(lensDistortion.intensity.value, distMax, waveTime * Time.deltaTime);
            chromaticAberration.intensity.value = Mathf.Lerp(chromaticAberration.intensity.value, chromMax, waveTime * Time.deltaTime);
            bloom.intensity.value = Mathf.Lerp(bloom.intensity.value, bloomMax, waveTime * Time.deltaTime);
        }
        else
        {
            playerObj.GetComponent<MeshRenderer>().material = materials[0];
            glasses.GetComponent<MeshRenderer>().material = materials[2];
            inWave = false;

            lensDistortion.intensity.value = Mathf.Lerp(lensDistortion.intensity.value, 0, waveTime * Time.deltaTime);
            chromaticAberration.intensity.value = Mathf.Lerp(chromaticAberration.intensity.value, 0.1f, waveTime * Time.deltaTime);
            bloom.intensity.value = Mathf.Lerp(bloom.intensity.value, 1, waveTime * Time.deltaTime);
        }
    }
}
