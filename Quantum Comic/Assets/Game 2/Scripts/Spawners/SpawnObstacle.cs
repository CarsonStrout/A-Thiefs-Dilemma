using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    public GameObject[] obstacles;

    public float timeBetweenSpawns;
    public float timer;
    public bool canSpawn;

    private void Update()
    {
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
        Vector2 randomPos = new Vector2(transform.position.x + Random.Range(-7f, 7f), transform.position.y);
        int randomObs = Random.Range(0, obstacles.Length);
        Instantiate(obstacles[randomObs], randomPos, obstacles[randomObs].transform.rotation);
    }
}
