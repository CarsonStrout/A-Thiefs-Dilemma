using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ColorTempChanger : MonoBehaviour
{
    [SerializeField] private Volume pp; // urp post processing
    private WhiteBalance whiteBalance;
    [SerializeField] private float speed;

    private void Start()
    {
        pp.profile.TryGet(out whiteBalance);
    }

    private void Update()
    {
        //whiteBalance.temperature.value = Mathf.Lerp(whiteBalance.temperature.value, -100, speed * Time.deltaTime);
        whiteBalance.temperature.value = Mathf.PingPong(speed * Time.time, 100) - 50;
    }
}
