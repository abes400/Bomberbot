using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeControl : MonoBehaviour
{
    public float rotateSpeed = 0.4f;
    bool touched = false;
    AudioSource src;

    Vector3 rot;

    // Start is called before the first frame update
    void Start()
    {
        rot = gameObject.transform.eulerAngles;
        touched = false;
        src = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        gameObject.transform.eulerAngles = new Vector3(rot.x, gameObject.transform.eulerAngles.y + rotateSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && !touched)
        {
            GameManager.life++;
            touched = true;
            transform.position = new Vector3(0, -100, 0);
            src.Play();
            Invoke("Kill", 1);
        }
    }

    void Kill()
    {
        gameObject.SetActive(false);
    }
}
