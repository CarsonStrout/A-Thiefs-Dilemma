using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnpauseAudio : MonoBehaviour
{
    private void Start()
    {
        AudioListener.pause = false;
    }
}
