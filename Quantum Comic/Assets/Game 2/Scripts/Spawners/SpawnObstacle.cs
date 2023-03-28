using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject[] obstacles;

    [Space(5)]
    [Header("Timers")]
    [SerializeField] private float timeBetweenSpawns;
    [SerializeField] private float timer;
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
        Vector2 randomPos = new Vector2(transform.position.x + Random.Range(-7f, 7f), transform.position.y);
        int randomObs = Random.Range(0, obstacles.Length);
        Instantiate(obstacles[randomObs], randomPos, obstacles[randomObs].transform.rotation);
    }
}
