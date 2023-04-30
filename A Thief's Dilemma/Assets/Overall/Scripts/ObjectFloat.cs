using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFloat : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float amplitude;

    private void Update()
    {
        transform.localPosition = new Vector2(transform.localPosition.x, Mathf.Sin(Time.time * speed) * amplitude);
    }
}
