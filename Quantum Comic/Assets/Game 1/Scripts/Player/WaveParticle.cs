using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveParticle : MonoBehaviour
{
    public Material[] materials;
    public GameObject playerObj, glasses;
    public bool inWave;

    private void Start()
    {
        playerObj.GetComponent<MeshRenderer>().material = materials[0];
        glasses.GetComponent<MeshRenderer>().material = materials[0];
        inWave = false;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerObj.GetComponent<MeshRenderer>().material = materials[1];
            glasses.GetComponent<MeshRenderer>().material = materials[3];
            inWave = true;
        }
        else
        {
            playerObj.GetComponent<MeshRenderer>().material = materials[0];
            glasses.GetComponent<MeshRenderer>().material = materials[2];
            inWave = false;
        }
    }
}
