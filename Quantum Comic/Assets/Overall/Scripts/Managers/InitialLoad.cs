using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialLoad : MonoBehaviour
{
    [SerializeField] private GameObject[] buttons;
    public static bool started = false;

    private void Awake()
    {
        if (!started)
        {
            for (int i = 0; i < buttons.Length; i++)
                buttons[i].SetActive(true);
            PlayerPrefs.DeleteAll();
        }
        else
            for (int i = 0; i < buttons.Length; i++)
                buttons[i].SetActive(false);
    }

    public void ComicStarted()
    {
        started = true;
    }
}
