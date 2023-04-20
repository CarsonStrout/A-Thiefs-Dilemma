using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFadeManager : MonoBehaviour
{
    [SerializeField] private AudioSource[] sounds;
    [SerializeField] private float[] maxVols;
    private bool fadeOut = false;

    private void Update()
    {
        if (!fadeOut)
        {
            for (int i = 0; i < sounds.Length; i++)
            {
                sounds[i].volume = Mathf.Lerp(sounds[i].volume, maxVols[i], 1.5f * Time.deltaTime);
            }
        }
        else
        {
            for (int i = 0; i < sounds.Length; i++)
            {
                sounds[i].volume = Mathf.Lerp(sounds[i].volume, 0, 1.5f * Time.deltaTime);
            }
        }
    }

    public void FadeAudio()
    {
        fadeOut = true;
    }
}
