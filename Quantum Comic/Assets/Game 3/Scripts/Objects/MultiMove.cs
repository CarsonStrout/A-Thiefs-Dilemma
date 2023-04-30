using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiMove : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Button[] buttons;

    [Space(5)]
    [SerializeField] private Vector2[] pos;
    [SerializeField] private float speed;

    private void Start()
    {
        transform.localPosition = pos[0];
    }

    private void Update()
    {
        if (!buttons[0].buttonActivated) // moves to original location of no buttons are activated
            transform.localPosition = Vector2.Lerp(transform.localPosition, pos[0], speed * Time.deltaTime);

        for (int i = buttons.Length - 1; i >= 0; i--) // move to most recent activated position
        {
            if (buttons[i].buttonActivated)
            {
                transform.localPosition = Vector2.Lerp(transform.localPosition, pos[i + 1], speed * Time.deltaTime);
                break;
            }
        }
    }
}
