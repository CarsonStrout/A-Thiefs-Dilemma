using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInstructions : MonoBehaviour
{
    [SerializeField] private GameObject instructionText;
    private void OnTriggerEnter(Collider other)
    {
        instructionText.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        instructionText.SetActive(false);
    }
}
