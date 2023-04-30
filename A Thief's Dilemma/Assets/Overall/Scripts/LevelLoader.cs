using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Animator transition;
    [SerializeField] private int levelToLoad;

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(levelToLoad));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        // play animation
        transition.SetTrigger("Start");

        // wait
        yield return new WaitForSecondsRealtime(1);

        // load scene
        SceneManager.LoadScene(levelIndex);

        Time.timeScale = 1f;
    }
}
