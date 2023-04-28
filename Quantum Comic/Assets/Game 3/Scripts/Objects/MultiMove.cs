using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiMove : MonoBehaviour
{
    [SerializeField] private Button[] buttons;
    [SerializeField] private Vector2[] pos;
    [SerializeField] private float speed;

    private void Start()
    {
        transform.localPosition = pos[0];
    }

    private void Update()
    {
        if (!buttons[0].buttonActivated)
            transform.localPosition = Vector2.Lerp(transform.localPosition, pos[0], speed * Time.deltaTime);

        for (int i = buttons.Length - 1; i >= 0; i--)
        {
            if (buttons[i].buttonActivated)
            {
                transform.localPosition = Vector2.Lerp(transform.localPosition, pos[i + 1], speed * Time.deltaTime);
                break;
            }
        }

        /* if (button.buttonActivated)
        {
            transform.localPosition = Vector2.Lerp(transform.localPosition, pos[1], speed * Time.deltaTime);
        }
        else
        {
            transform.localPosition = Vector2.Lerp(transform.localPosition, pos[0], speed * Time.deltaTime);
        } */
    }
}
