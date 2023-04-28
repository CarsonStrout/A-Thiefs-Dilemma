using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private SpriteRenderer buttonSprite;
    [SerializeField] private CinemachineShake cinemachineShake;
    [SerializeField] private AudioSource buttonAudio;
    [SerializeField] private AudioSource doorAudio;
    [SerializeField] private float speed;
    private Color tmp;
    public bool finalButton;
    private bool canActivate;
    [HideInInspector] public bool buttonActivated;

    private void Start()
    {
        canActivate = false;
        buttonActivated = false;

        tmp = buttonSprite.color;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.E) && canActivate && !buttonActivated)
        {
            buttonActivated = true;
            if (finalButton)
            {
                cinemachineShake.ShakeCamera(2.4f, 2.5f);
                buttonAudio.Play();
                doorAudio.Play();
            }
        }

        if (!buttonActivated)
        {
            tmp.a = Mathf.Lerp(tmp.a, 1, speed * Time.deltaTime);
        }
        else
        {
            tmp.a = Mathf.Lerp(tmp.a, 0, speed * Time.deltaTime);
        }

        buttonSprite.color = tmp;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        canActivate = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        canActivate = false;
    }
}
