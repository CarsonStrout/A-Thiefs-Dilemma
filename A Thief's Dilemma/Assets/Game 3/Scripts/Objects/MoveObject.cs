using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Button button;

    [Space(5)]
    [SerializeField] private Vector2[] pos = new Vector2[2];
    [SerializeField] private float speed;

    private void Start()
    {
        transform.localPosition = pos[0];
    }

    private void Update()
    {
        if (button.buttonActivated) // can move an object between 2 positions
        {
            transform.localPosition = Vector2.Lerp(transform.localPosition, pos[1], speed * Time.deltaTime);
        }
        else
        {
            transform.localPosition = Vector2.Lerp(transform.localPosition, pos[0], speed * Time.deltaTime);
        }
    }
}
