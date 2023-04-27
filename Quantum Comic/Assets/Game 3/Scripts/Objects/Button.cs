using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private SpriteRenderer buttonSprite;
    [SerializeField] private float speed;
    private Color tmp;
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
        if (Input.GetKey(KeyCode.E) && canActivate)
        {
            buttonActivated = true;
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
