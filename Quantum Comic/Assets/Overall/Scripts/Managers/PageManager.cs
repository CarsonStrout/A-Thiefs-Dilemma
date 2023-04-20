using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject[] virtualCam;
    private int activePage;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        activePage = PlayerPrefs.GetInt("PageNumber", 0);
        virtualCam[activePage].SetActive(true);
    }

    public void NextPage()
    {
        virtualCam[activePage].SetActive(false);
        virtualCam[activePage + 1].SetActive(true);
        activePage++;
    }

    public void PreviousPage()
    {
        virtualCam[activePage].SetActive(false);
        virtualCam[activePage - 1].SetActive(true);
        activePage--;
    }
}
