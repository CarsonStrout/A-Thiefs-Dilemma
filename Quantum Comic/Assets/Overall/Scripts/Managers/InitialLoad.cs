using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialLoad : MonoBehaviour
{
    public static bool started = false;

    private void Awake()
    {
        if (!started)
        {
            PlayerPrefs.DeleteAll();
        }
    }

    public void ComicStarted()
    {
        started = true;
    }
}
