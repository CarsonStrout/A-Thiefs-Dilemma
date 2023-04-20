using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RainManager : MonoBehaviour
{
    [SerializeField] private AudioSource rainstorm;
    [SerializeField] private CinemachineVirtualCamera[] cms;

    private void Update()
    {
        if (cms[0].isActiveAndEnabled || cms[1].isActiveAndEnabled)
        {
            rainstorm.volume = Mathf.Lerp(rainstorm.volume, 0.25f, 1.5f * Time.deltaTime);
        }
        else
        {
            rainstorm.volume = Mathf.Lerp(rainstorm.volume, 0f, 1.5f * Time.deltaTime);
        }
    }
}
