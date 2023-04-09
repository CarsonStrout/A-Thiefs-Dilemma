using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject[] obstacles;
    [SerializeField] private Vector2[] spawnPos;

    [Space(5)]
    [Header("Timers")]
    [SerializeField] private float timeBetweenSpawns;
    [SerializeField] private float timer;
    [SerializeField] private float decreaseTime;
    [SerializeField] private float minTime;

    [Space(5)]
    [SerializeField] private bool canSpawn;

    private void Update()
    {
        // plays the timer after an object is spawned
        if (!canSpawn)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenSpawns)
            {
                canSpawn = true;
                timer = 0;
                if (timeBetweenSpawns > minTime)
                {
                    timeBetweenSpawns -= decreaseTime;
                }
            }
        }
        else
        {
            Spawn();
            canSpawn = false;
        }
    }

    public void Spawn()
    {
        // picks a random position for the object spawn
        Vector2 randomPos = new Vector2(spawnPos[Random.Range(0, 2)].x, transform.position.y);

        int randomObs = Random.Range(0, obstacles.Length);
        Instantiate(obstacles[randomObs], randomPos, obstacles[randomObs].transform.rotation);
    }
}
