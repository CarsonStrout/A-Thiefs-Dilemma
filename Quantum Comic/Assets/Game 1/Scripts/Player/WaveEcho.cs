using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveEcho : MonoBehaviour
{
    private float timeBtwSpawns;
    [Header("Spawn Speed")]
    public float startTimeBtwSpawns;

    [Space(5)]
    [Header("References")]
    public WaveParticle waveParticle;
    public GameObject player;
    public PlayerMovement movement;
    public GameObject echo;

    private void Update()
    {
        // when player is in wave form, spawns "echoes" of player behind, emulating a continuous light effect
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
