using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILookAtCam : MonoBehaviour
{
    private void LateUpdate()
    {
        // causes UI to always point towards the main cam
        transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward, Camera.main.transform.rotation * Vector3.up);
    }
}
