using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameManager2 gameManager;
    [SerializeField] private GameObject[] obstacles;
    [SerializeField] private Vector2[] leftSpawnPos;
    [SerializeField] private Vector2[] rightSpawnPos;

    [Space(5)]
    [Header("Timers")]
    [SerializeField] private float timeBetweenSpawns;
    [SerializeField] private float timer;
    [SerializeField] private float decreaseTime;
    [SerializeField] private float minTime;

    private float lastSpawned;
    private bool canSpawn;
    private bool updateSpeed1;
    private bool updateSpeed2;
    private bool updateSpeed3;

    private void Start()
    {
        updateSpeed1 = false;
        updateSpeed2 = false;
        updateSpeed3 = false;
    }

    private void Update()
    {
        if (gameManager.gameComplete)
            return;

        if (gameManager.gameLength < 50 && !updateSpeed1)
        {
            timeBetweenSpawns -= decreaseTime;
            updateSpeed1 = true;
        }

        if (gameManager.gameLength < 40 && !updateSpeed2)
        {
            timeBetweenSpawns -= decreaseTime;
            updateSpeed2 = true;
        }

        if (gameManager.gameLength < 30 && !updateSpeed3)
        {
            timeBetweenSpawns -= decreaseTime;
            updateSpeed3 = true;
        }

        if (!canSpawn)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenSpawns)
            {
                canSpawn = true;
                timer = 0;
            }
        }
        else if (lastSpawned == 0)
        {
            SpawnRight();
            canSpawn = false;
        }
        else if (lastSpawned == 1)
        {
            SpawnLeft();
            canSpawn = false;
        }
    }

    private void SpawnLeft()
    {
        // picks a random position for the object spawn
        Vector2 randomPos = new Vector2(leftSpawnPos[Random.Range(0, 3)].x, transform.position.y);

        int randomObs = Random.Range(0, obstacles.Length);
        Instantiate(obstacles[randomObs], randomPos, obstacles[randomObs].transform.rotation);
        lastSpawned = 0;
    }

    private void SpawnRight()
    {
        // picks a random position for the object spawn
        Vector2 randomPos = new Vector2(rightSpawnPos[Random.Range(0, 3)].x, transform.position.y);

        int randomObs = Random.Range(0, obstacles.Length);
        Instantiate(obstacles[randomObs], randomPos, obstacles[randomObs].transform.rotation);
        lastSpawned = 1;
    }
}
