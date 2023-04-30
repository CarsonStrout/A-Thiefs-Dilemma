using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLean : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private RewindTime rewindTime;
    [SerializeField] private Transform body;

    [Space(5)]
    [Header("Values")]
    [SerializeField] private float speed;
    [SerializeField] private float tilt;

    private void Update()
    {
        // will slightly rotate the player sprite towards the direction of movement
        if (!rewindTime.isRewinding)
        {
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                body.rotation = Quaternion.Lerp(body.rotation, Quaternion.Euler(0, 0, -tilt), speed * Time.deltaTime);
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                body.rotation = Quaternion.Lerp(body.rotation, Quaternion.Euler(0, 0, tilt), speed * Time.deltaTime);
            else
                body.rotation = Quaternion.Lerp(body.rotation, Quaternion.Euler(0, 0, 0), speed * Time.deltaTime);
        }
        else
            body.rotation = Quaternion.Lerp(body.rotation, Quaternion.Euler(0, 0, 0), speed * Time.deltaTime);
    }
}
