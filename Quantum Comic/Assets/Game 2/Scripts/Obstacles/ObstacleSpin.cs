using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpin : MonoBehaviour
{
    [SerializeField] private float spinRateMax;
    private float spinRate;

    private void Start()
    {
        spinRate = Random.Range(-spinRateMax, spinRateMax);
    }

    private void Update()
    {
        transform.Rotate(0, 0, spinRate * Time.deltaTime);
    }
}
