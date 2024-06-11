using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static int roombaCount = 0, crateCount = 0, life = 5, score = 0, addedScore = 0;


    public int startFromLevel = 1;

    public static bool isPlaying;

    static GameObject pauseMenu;
    public static CanvasGroup canvasGroup;
    public static AudioSource src;

    // Start is called before the first frame update
    void Start()
    {
        

        src = GetComponent<AudioSource>();

        roombaCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        crateCount = GameObject.FindGameObjectsWithTag("Crate").Length;
        pauseMenu = GameObject.FindGameObjectWithTag("PauseMenu");
        canvasGroup = pauseMenu.GetComponent<CanvasGroup>();
        //canvasGroup.interactable = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;


        isPlaying = true;
        

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if(isPlaying)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                canvasGroup.alpha = 1;
                canvasGroup.interactable = true;
                isPlaying = false;
            } else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                canvasGroup.alpha = 0;
                canvasGroup.interactable = false;
                isPlaying = true;
            }
        }
    }

    public static void Reset()
    {
        life = 5;
        addedScore = 0;
        score = 0;
    }

    
}
