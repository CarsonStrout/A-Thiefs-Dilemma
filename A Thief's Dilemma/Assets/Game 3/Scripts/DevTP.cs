using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevTP : MonoBehaviour
{
    [SerializeField] private GameObject tp;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Period))
            transform.position = tp.transform.position;
    }
}
