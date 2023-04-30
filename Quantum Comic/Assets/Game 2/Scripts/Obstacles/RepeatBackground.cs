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
        repeatHeight = GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }

    private void Update()
    {
        if (transform.position.y < startPos.y - repeatHeight) // permanently loops background
            transform.position = startPos;
    }
}
