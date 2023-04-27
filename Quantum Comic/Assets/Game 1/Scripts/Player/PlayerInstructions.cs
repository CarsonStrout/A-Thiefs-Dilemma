using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInstructions : MonoBehaviour
{
    [SerializeField] private TMP_Text instructionText;
    [SerializeField] private float speed;
    private bool active;

    private void Update()
    {
        if (active)
            instructionText.alpha = Mathf.Lerp(instructionText.alpha, 1, speed * Time.deltaTime);
        else
            instructionText.alpha = Mathf.Lerp(instructionText.alpha, 0, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        active = true;
    }

    private void OnTriggerExit(Collider other)
    {
        active = false;
    }
}
