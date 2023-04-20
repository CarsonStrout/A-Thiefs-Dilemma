using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager2 : MonoBehaviour
{
    [SerializeField] private LevelLoader levelLoader;
    public float gameLength;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private TMP_Text instructionText;
    [SerializeField] private GameObject gameOverText;

    private int pageLoad = 1;

    public bool loseGame;
    public bool gameComplete;
    public bool freeEnd;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        gameComplete = false;
        freeEnd = false;
    }

    private void Update()
    {
        if (loseGame)
        {
            gameOverText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.R))
                SceneManager.LoadScene(3);
        }

        if (gameComplete)
            PlayerPrefs.SetInt("PageNumber", pageLoad);

        if (gameLength < 57 && gameLength > 56)
            instructionText.SetText("GO!");

        if (gameLength < 56)
            instructionText.SetText("");

        if (gameLength < 5)
            gameComplete = true;

        if (gameLength < 3)
            freeEnd = true;

        if (gameLength < 0)
            levelLoader.LoadNextLevel();

        if (gameLength > 0 && !loseGame)
        {
            gameLength -= Time.deltaTime;
            int rounded = (int)gameLength;
            timerText.text = rounded.ToString();
        }

    }
}
