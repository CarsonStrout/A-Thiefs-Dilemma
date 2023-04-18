using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager2 : MonoBehaviour
{
    [SerializeField] private LevelLoader levelLoader;
    [SerializeField] private float gameLength;
    [SerializeField] private TMP_Text text;
    private int pageLoad = 1;

    public bool gameComplete;

    public bool freeEnd;

    private void Start()
    {
        gameComplete = false;
        freeEnd = false;
    }

    private void Update()
    {
        if (gameComplete)
            PlayerPrefs.SetInt("PageNumber", pageLoad);

        if (gameLength < 5)
            gameComplete = true;

        if (gameLength < 3)
            freeEnd = true;

        if (gameLength < 0)
            levelLoader.LoadNextLevel();

        if (gameLength > 0)
        {
            gameLength -= Time.deltaTime;
            int rounded = (int)gameLength;
            text.text = rounded.ToString();
        }

    }
}
