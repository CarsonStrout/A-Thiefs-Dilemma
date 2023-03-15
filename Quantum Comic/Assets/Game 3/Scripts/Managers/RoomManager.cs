using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [Header("References")]
    public GameObject virtualCam;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // will move the camera to different rooms as determined by confiners
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            virtualCam.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // turns off the active camera to allow for transitions
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            virtualCam.SetActive(false);
        }
    }
}
