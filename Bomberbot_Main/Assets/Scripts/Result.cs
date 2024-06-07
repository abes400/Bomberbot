using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    public Sprite gameOver, tryAgain, lvlComplete, congrats;

    public const int GAME_OVER = 0, TRY_AGAIN = 1, LVL_COMPLETE = 2, CONGRATS = 3;
    public AudioClip game_over, try_again, lvl_complete, you_win;
    AudioSource src;

    private Image image;
    private CanvasGroup canvasGroup;
    // Start is called before the first frame update
    private void Start()
    {
        image = gameObject.GetComponent<Image>();
        canvasGroup = gameObject.GetComponent<CanvasGroup>();
        src = GetComponent<AudioSource>();
    }

    public void Show(int mode)
    {
        switch (mode)
        {
            case 0:
                src.clip = game_over;
                image.sprite = gameOver;
                break;
            case 1:
                src.clip = try_again;
                image.sprite = tryAgain;
                break;
            case 2:
                src.clip = lvl_complete;
                image.sprite = lvlComplete;
                break;
            case 3:
                src.clip = you_win;
                image.sprite = congrats;
                break;
        }

        src.Play();
        canvasGroup.alpha = 1;
    }

    public void Hide()
    {
        canvasGroup.alpha = 0;
    }
}
