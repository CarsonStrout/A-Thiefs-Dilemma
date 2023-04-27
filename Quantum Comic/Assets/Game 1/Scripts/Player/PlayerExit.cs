using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerExit : MonoBehaviour
{
    [SerializeField] private TMP_Text exitUI;
    [SerializeField] private float speed;
    [SerializeField] private PauseMenu loader;
    [SerializeField] private SoundFadeManager soundFadeManager;
    [SerializeField] private AudioSource doorSound;
    private bool canExit = false;
    private bool hasExited = false;

    private void Update()
    {
        if (canExit)
        {
            exitUI.alpha = Mathf.Lerp(exitUI.alpha, 1, speed * Time.deltaTime);

            if (Input.GetKey(KeyCode.E) && !hasExited)
            {
                hasExited = true;
                doorSound.Play();
                soundFadeManager.FadeAudio();
                loader.LoadComic();
            }
        }
        else
            exitUI.alpha = Mathf.Lerp(exitUI.alpha, 0, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        canExit = true;
    }

    private void OnTriggerExit(Collider other)
    {
        canExit = false;
    }
}
