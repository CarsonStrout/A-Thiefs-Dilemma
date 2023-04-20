using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialLoad : MonoBehaviour
{
    [SerializeField] private GameObject button;
    public static bool started = false;

    private void Awake()
    {
        if (!started)
        {
            button.SetActive(true);
            PlayerPrefs.DeleteAll();
        }
        else
            button.SetActive(false);
    }

    public void ComicStarted()
    {
        started = true;
    }
}
