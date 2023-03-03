using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float lowerBound = -15;

    private void Update()
    {
        if (transform.position.y < lowerBound)
        {
            Destroy(gameObject);
        }
    }
}
