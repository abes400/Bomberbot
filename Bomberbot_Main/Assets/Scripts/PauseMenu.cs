using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    int lastWidth, lastHeight;

    public void Start()
    {
        lastWidth = Screen.currentResolution.width * 3 / 2;
        lastHeight = Screen.currentResolution.height * 3 / 2;
    }
    public void ResumeLevel()
    {
        GameManager.canvasGroup.alpha = 0;
        GameManager.canvasGroup.interactable = false;
        GameManager.isPlaying = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ResetLvl()
    {
        GameManager.score -= GameManager.addedScore;
        GameManager.addedScore = 0;
        
        GameManager.canvasGroup.alpha = 0;
        GameManager.isPlaying = true;
        GameManager.canvasGroup.interactable = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Fullscreen()
    {
        if (Screen.fullScreen) Screen.SetResolution(lastWidth, lastHeight, false);
        else
        {
            lastWidth = Screen.width;
            lastHeight = Screen.height;
            Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);

        }
    }

    public void QuitGame()
    {
        GameManager.canvasGroup.alpha = 0;
        GameManager.canvasGroup.interactable = false;
        GameManager.isPlaying = false;
        SceneManager.LoadScene("Main Menu");
        GameObject.FindGameObjectWithTag("OSD").SetActive(false);
    }
}
