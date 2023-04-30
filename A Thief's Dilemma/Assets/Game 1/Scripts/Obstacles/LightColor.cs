using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightColor : MonoBehaviour
{
    [SerializeField] private Light secretLight;

    void Start()
    {
        StartCoroutine(ColorChangeRoutine());
    }

    private IEnumerator ColorChangeRoutine()
    {
        while (true)
        {
            var startColor = secretLight.color;
            var endColor = new Color32(System.Convert.ToByte(Random.Range(0, 255)), System.Convert.ToByte(Random.Range(0, 255)), System.Convert.ToByte(Random.Range(0, 255)), 255);

            var t = 0f;
            while (t < 1)
            {
                t = Mathf.Min(1, t + Time.deltaTime); // Multiply Time.deltaTime by some constant to speed/slow the transition.
                secretLight.color = Color.Lerp(startColor, endColor, t);
                yield return null;
            }

            yield return new WaitForSeconds(0.5f);
        }
    }
}
