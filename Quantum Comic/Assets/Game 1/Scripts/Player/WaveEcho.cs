using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveEcho : MonoBehaviour
{
    [Header("Spawn Speed")]
    [SerializeField] private float startTimeBtwSpawns;
    private float timeBtwSpawns;

    [Space(5)]
    [Header("References")]
    [SerializeField] private WaveParticle waveParticle;
    [SerializeField] private GameObject player;
    [SerializeField] private PlayerMovement movement;
    [SerializeField] private GameObject echo;

    private void Update()
    {
        // when player is in wave form, spawns "echoes" of player behind, emulating a continuous light effect
        if (waveParticle.inWave && (movement.horizontal != 0 || movement.vertical != 0))
        {
            if (timeBtwSpawns <= 0)
            {
                GameObject instance = Instantiate(echo, transform.position, player.transform.rotation);
                Destroy(instance, 1f);
                timeBtwSpawns = startTimeBtwSpawns;
            }
            else
            {
                timeBtwSpawns -= Time.deltaTime;
            }
        }
    }
}
