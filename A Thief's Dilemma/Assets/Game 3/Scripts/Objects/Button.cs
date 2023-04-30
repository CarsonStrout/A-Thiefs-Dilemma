using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private ObjectAppear[] objectAppear;
    [SerializeField] private SpriteRenderer buttonSprite;
    [SerializeField] private CinemachineShake cinemachineShake;
    [SerializeField] private AudioSource buttonAudio;
    [SerializeField] private AudioSource doorAudio;

    [Space(5)]
    [SerializeField] private float speed;

    [Space(5)]
    public bool finalButton;

    private Color tmp;
    private bool canActivate;
    private bool appear = false;
    [HideInInspector] public bool buttonActivated;

    private void Start()
    {
        canActivate = false;
        buttonActivated = false;

        tmp = buttonSprite.color;

        if (objectAppear.Length > 0) // since both scripts effect alpha values, need to check if object has both scripts assigned
            appear = true;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.E) && canActivate && !buttonActivated)
        {
            buttonActivated = true;
            buttonAudio.Play();
            if (finalButton) // final button is essentially any button that moves a door / large object
            {
                cinemachineShake.ShakeCamera(2.4f, 2.5f);
                doorAudio.Play();
            }
        }

        if (appear)
        {
            if (!buttonActivated && objectAppear[0].button.buttonActivated)
            {
                tmp.a = Mathf.Lerp(tmp.a, 1, speed * Time.deltaTime);
            }
            else
            {
                tmp.a = Mathf.Lerp(tmp.a, 0, speed * Time.deltaTime);
            }

            buttonSprite.color = tmp;
        }
        else
        {
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
