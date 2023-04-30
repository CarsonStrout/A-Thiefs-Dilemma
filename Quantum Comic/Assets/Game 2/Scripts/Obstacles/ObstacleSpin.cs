using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpin : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private float spinRateMax;
    private float spinRate;

    private void Start()
    {
        spinRate = Random.Range(-spinRateMax, spinRateMax); // picks randomly so not every object is the same
    }

    private void Update()
    {
        transform.Rotate(0, 0, spinRate * Time.deltaTime);
    }
}
