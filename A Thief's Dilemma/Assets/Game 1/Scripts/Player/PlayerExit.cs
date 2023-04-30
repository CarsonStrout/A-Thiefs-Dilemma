using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerExit : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TMP_Text exitUI;
    [SerializeField] private PauseMenu loader;
    [SerializeField] private SoundFadeManager soundFadeManager;
    [SerializeField] private AudioSource doorSound;

    [Space(5)]
    [Header("Stats")]
    [SerializeField] private float speed;

    private bool canExit = false;
    private bool hasExited = false;

    private void Update()
    {
        if (canExit)
        {
            exitUI.alpha = Mathf.Lerp(exitUI.alpha, 1, speed * Time.deltaTime); // makes UI visible

            if (Input.GetKey(KeyCode.E) && !hasExited) // can only activate exit once
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
