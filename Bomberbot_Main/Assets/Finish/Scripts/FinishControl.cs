using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishControl : MonoBehaviour
{
    public float rotateSpeed = 0.4f;
    public string nextScene;

    Vector3 rot;

    // Start is called before the first frame update
    void Start()
    {
        rot = gameObject.transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.eulerAngles = new Vector3(rot.x, gameObject.transform.eulerAngles.y + rotateSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && GameManager.roombaCount == 0)
        {
            other.gameObject.active = false;
            Stop();
        }
    }

    private void Stop()
    {
        GameManager.isPlaying = false;
        if(SceneManager.GetActiveScene().name == "Level 6")
        {
            GameObject.FindGameObjectWithTag("Result").GetComponent<Result>().Show(Result.CONGRATS);
        }
        else
        {
            GameObject.FindGameObjectWithTag("Result").GetComponent<Result>().Show(Result.LVL_COMPLETE);
        }
        Invoke("Next", 2);
    }

    private void Next()
    {
        GameObject.FindGameObjectWithTag("Result").GetComponent<Result>().Hide();
        if (SceneManager.GetActiveScene().name == "Level 3") GameObject.Destroy(GameObject.FindGameObjectWithTag("OSD"));
        SceneManager.LoadScene(nextScene);
    }
}
