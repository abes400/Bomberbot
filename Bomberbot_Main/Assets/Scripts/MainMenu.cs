using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public CanvasGroup canvasGroupMain, canvasGroupInstructions, canvasGroupCredits, canvasGroupQuit;
    int lastWidth, lastHeight;
    

    public void NewGame()
    {
        canvasGroupMain.alpha = 0;
        canvasGroupMain.interactable = false;
        canvasGroupMain.blocksRaycasts = false;

        GameManager.Reset();
        
        SceneManager.LoadScene("Level 1");
    }

    public void Start()
    {
        lastWidth = Screen.currentResolution.width * 3 / 2;
        lastHeight = Screen.currentResolution.height * 3 / 2;
    }

    public void LoadGame()
    {
        
    }
    public void Instructions()
    {
        canvasGroupMain.interactable = false;
        canvasGroupMain.blocksRaycasts = false;
        canvasGroupMain.alpha = 0;
        canvasGroupInstructions.interactable = true;
        canvasGroupInstructions.blocksRaycasts = true;
        canvasGroupInstructions.alpha = 1;
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


    public void Credits()
    {
        canvasGroupMain.interactable = false;
        canvasGroupMain.blocksRaycasts = false;
        canvasGroupMain.alpha = 0;
        canvasGroupCredits.interactable = true;
        canvasGroupCredits.blocksRaycasts = true;
        canvasGroupCredits.alpha = 1;
    }

    public void QuitInit()
    {
        canvasGroupMain.interactable = false;
        canvasGroupMain.blocksRaycasts = true;
        canvasGroupMain.alpha = 0;
        canvasGroupQuit.interactable = true;
        canvasGroupQuit.blocksRaycasts = true;
        canvasGroupQuit.alpha = 1;
    }

    public void QuitYes()
    {
        Application.Quit();
    }

    public void Back()
    {
        canvasGroupQuit.interactable = false;
        canvasGroupQuit.blocksRaycasts = false;
        canvasGroupQuit.alpha = 0;
        canvasGroupCredits.interactable = false;
        canvasGroupCredits.blocksRaycasts = false;
        canvasGroupCredits.alpha = 0;
        canvasGroupInstructions.interactable = false;
        canvasGroupInstructions.blocksRaycasts = false;
        canvasGroupInstructions.alpha = 0;
        canvasGroupMain.interactable = true;
        canvasGroupMain.blocksRaycasts = true;
        canvasGroupMain.alpha = 1;
    }
}
