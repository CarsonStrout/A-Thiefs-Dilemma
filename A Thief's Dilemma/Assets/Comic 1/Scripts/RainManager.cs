using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RainManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private AudioSource rainstorm;
    [SerializeField] private CinemachineVirtualCamera[] cms;

    private void Update()
    {
        // Allows rainfall audio to play only when the first panel is visible, fades out otherwise
        if (cms[0].isActiveAndEnabled || cms[1].isActiveAndEnabled)
        {
            rainstorm.volume = Mathf.Lerp(rainstorm.volume, 0.5f, 1.5f * Time.deltaTime);
        }
        else
        {
            rainstorm.volume = Mathf.Lerp(rainstorm.volume, 0f, 1.5f * Time.deltaTime);
        }
    }
}
