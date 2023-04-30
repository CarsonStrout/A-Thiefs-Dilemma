using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundColorManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Camera cam;
    [SerializeField] private Color[] colors;
    private int colorPos;
    private int nextColorPos;

    [Space(5)]
    [SerializeField] private float duration = 1.5F;

    private void Start()
    {
        colorPos = PlayerPrefs.GetInt("PageNumber", 0);
        nextColorPos = colorPos;
        cam.clearFlags = CameraClearFlags.SolidColor;
    }

    private void Update()
    {
        cam.backgroundColor = Color.Lerp(cam.backgroundColor, colors[nextColorPos], duration * Time.deltaTime);
    }

    public void NextColor()
    {
        nextColorPos = colorPos + 1;
        colorPos++;
    }

    public void PreviousColor()
    {
        nextColorPos = colorPos - 1;
        colorPos--;
    }
}
