using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector2 startPos;
    private float repeatHeight;

    private void Start()
    {
        startPos = transform.position;
        //repeatHeight = GetComponent<BoxCollider2D>().size.y / 2f;
        repeatHeight = GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }

    private void Update()
    {
        if (transform.position.y < startPos.y - repeatHeight)
            transform.position = startPos;
    }

    /* private void Update()
    {
        if (transform.position.y < -20.25f)
            transform.position = new Vector2(0, 20.25f);
    } */
}
