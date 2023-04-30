using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInstructions : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TMP_Text instructionText;

    [Space(5)]
    [Header("Stats")]
    [SerializeField] private float speed;
    private bool active;

    private void Update()
    {
        // visible if active, slowly disappears otherwise
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
