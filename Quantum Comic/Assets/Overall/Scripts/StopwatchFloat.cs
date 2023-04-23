using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopwatchFloat : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float amplitude;

    private void Update()
    {
        transform.position = new Vector2(-5, Mathf.Sin(Time.time * speed) * amplitude);
    }
}
