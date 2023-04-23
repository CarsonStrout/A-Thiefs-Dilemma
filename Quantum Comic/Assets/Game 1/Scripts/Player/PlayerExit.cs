using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExit : MonoBehaviour
{
    [SerializeField] private GameObject exitUI;
    [SerializeField] private PauseMenu loader;
    [SerializeField] private SoundFadeManager soundFadeManager;
    [SerializeField] private AudioSource doorSound;
    private bool canExit = false;
    private bool hasExited = false;

    private void Update()
    {
        if (canExit && Input.GetKey(KeyCode.E) && !hasExited)
        {
            hasExited = true;
            doorSound.Play();
            soundFadeManager.FadeAudio();
            loader.LoadComic();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        exitUI.SetActive(true);
        canExit = true;
    }

    private void OnTriggerExit(Collider other)
    {
        exitUI.SetActive(false);
        canExit = false;
    }
}
