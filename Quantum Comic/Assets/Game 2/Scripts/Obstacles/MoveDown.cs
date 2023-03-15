using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 40.0f;

    private void Update()
    {
        // constantly moves objects down
        transform.Translate(Vector3.down * Time.deltaTime * speed);
    }
}
