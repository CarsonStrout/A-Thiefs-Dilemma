using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class RewindTime : MonoBehaviour
{
    public bool isRewinding = false;

    List<Vector3> positions;

    public float recordTime = 5f;

    public TrailRenderer tr;

    public Volume pp;
    private ChromaticAberration chromaticAberration;
    private Bloom bloom;
    private ColorAdjustments colorAdjustments;

    public float chromMax;
    public float bloomMax;
    public float colorMax;
    public float transitionTime;

    private void Start()
    {
        positions = new List<Vector3>();

        pp.profile.TryGet(out chromaticAberration);
        pp.profile.TryGet(out bloom);
        pp.profile.TryGet(out colorAdjustments);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
            StartRewind();
        if (Input.GetKeyUp(KeyCode.LeftShift))
            StopRewind();

        ProcessChange();

        if (isRewinding)
            tr.gameObject.SetActive(true);
        else
            tr.gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (isRewinding)
        {
            Rewind();
        }
        else
        {
            Record();
        }
    }

    void Rewind()
    {
        if (positions.Count > 0)
        {
            transform.position = positions[0];
            positions.RemoveAt(0);
        }
        else
            StopRewind();
    }

    private void ProcessChange()
    {
        if (isRewinding)
        {
            chromaticAberration.intensity.value = Mathf.Lerp(chromaticAberration.intensity.value, chromMax, transitionTime * Time.deltaTime);
            bloom.intensity.value = Mathf.Lerp(bloom.intensity.value, bloomMax, transitionTime * Time.deltaTime);
            colorAdjustments.hueShift.value = Mathf.Lerp(colorAdjustments.hueShift.value, colorMax, transitionTime * Time.deltaTime);
        }
        else
        {
            chromaticAberration.intensity.value = Mathf.Lerp(chromaticAberration.intensity.value, 0.2f, transitionTime * Time.deltaTime);
            bloom.intensity.value = Mathf.Lerp(bloom.intensity.value, 5, transitionTime * Time.deltaTime);
            colorAdjustments.hueShift.value = Mathf.Lerp(colorAdjustments.hueShift.value, 0, transitionTime * Time.deltaTime);
        }
    }

    void Record()
    {
        if (positions.Count > Mathf.Round(recordTime / Time.fixedDeltaTime))
            positions.RemoveAt(positions.Count - 1);
        positions.Insert(0, transform.position);
    }

    public void StartRewind()
    {
        isRewinding = true;
    }

    public void StopRewind()
    {
        isRewinding = false;
    }
}
