using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveEcho : MonoBehaviour
{
    public WaveParticle waveParticle;
    public GameObject player;
    public PlayerMovement movement;
    private float timeBtwSpawns;
    public float startTimeBtwSpawns;
    public GameObject echo;

    private void Update()
    {
        if (waveParticle.inWave && (movement.horizontal != 0 || movement.vertical != 0))
        {
            if (timeBtwSpawns <= 0)
            {
                GameObject instance = Instantiate(echo, transform.position, player.transform.rotation);
                Destroy(instance, 2f);
                timeBtwSpawns = startTimeBtwSpawns;
            }
            else
            {
                timeBtwSpawns -= Time.deltaTime;
            }
        }
    }
}
