using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed;

    private void Update()
    {
        // constantly moves objects down
        transform.Translate(Vector3.down * Time.deltaTime * speed);
    }
}
