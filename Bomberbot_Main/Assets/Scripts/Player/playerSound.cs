using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSound : MonoBehaviour
{
    public AudioClip[] clips;
    public AudioSource src;
    bool pressed = false;
    int mode = 0;

    // Start is called before the first frame update
    void Start()
    {
        src = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) ||
            (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.DownArrow)) ||
            (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.LeftArrow)) ||
            (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)))
        {
            
            if (!pressed)
            {
                pressed = true;
                mode = 0;
                src.clip = clips[0];
                src.Play();
            }
        }
        else if ((Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow)) ||
            (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.DownArrow)) ||
            (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.LeftArrow)) ||
            (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow)))
        {
            
            if(pressed)
            {
                pressed = false;
                mode = 2;
                src.clip = clips[2];
                src.Play();
            }
        } else if(pressed)
        {
            if(mode != 1)
            {
                mode = 1;
                src.clip = clips[1];
            }
            if (!src.isPlaying) src.Play();
        }
    }
}
