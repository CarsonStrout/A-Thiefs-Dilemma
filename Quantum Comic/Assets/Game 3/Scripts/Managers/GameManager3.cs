using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager3 : MonoBehaviour
{
    [HideInInspector] public bool playerDeath;

    private void Start()
    {
        playerDeath = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
