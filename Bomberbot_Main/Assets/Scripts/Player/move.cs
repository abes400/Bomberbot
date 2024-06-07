using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;
using UnityEngine.SceneManagement;

public class move : MonoBehaviour
{
    CharacterController motionizer;
    public Vector3 movector;
    public AudioSource src;
//0.01f
    public float speed = 0.01f, coeff = 1f;
    int step;
    public int fullstep = 10; // 62 idi
    float rotateY = 0;
    public GameObject bomb;
    public bomb bombControl;
    public float force;
    bool alreadyHurt;

    Vector3 initPosition;


    // Start is called before the first frame update
    void Start()
    {
        motionizer = GetComponent<CharacterController>();
        rotateY = -90.0f;
        transform.eulerAngles = new Vector3(0, rotateY, 0);
        step = fullstep;
        movector = new Vector3(0, 0, 0);
        bomb = GameObject.FindGameObjectWithTag("Bomb");
        bomb.SetActive(false);

        initPosition = transform.position;


        src = GetComponent<AudioSource>(); //////////////////////////////////////////////////////////////////////////////////////////////////

    }


    // Update is called once per frame
    void Update()
    {
        if (GameManager.isPlaying)
        {
                if (Input.GetKey(KeyCode.Space) && step == fullstep && !bomb.active)
                {

                    bomb.transform.position = new Vector3(transform.position.x, 0.373f, transform.position.z);
                    bomb.SetActive(true);
                    bombControl.Detonate();
                }
                if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && step == fullstep)
                {
                    rotateY = -90.0f;
                    transform.eulerAngles = new Vector3(0, rotateY, 0);
                    step = 0;
                    movector.x = 0;
                    movector.z = speed;
                    src.Play(); /////////////////////////////////////////////////////////////////////////////////////////////
            }
                else if ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && step == fullstep)
                {
                    rotateY = 90.0f;
                    transform.eulerAngles = new Vector3(0, rotateY, 0);
                    step = 0;
                    movector.x = 0;
                    movector.z = -speed;
                    src.Play(); /////////////////////////////////////////////////////////////////////////////////////////////
            }
                else if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && step == fullstep)
                {
                    rotateY = 180.0f;
                    transform.eulerAngles = new Vector3(0, rotateY, 0);
                    step = 0;
                    movector.x = -speed;
                    movector.z = 0;
                    src.Play(); /////////////////////////////////////////////////////////////////////////////////////////////
            }
                else if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && step == fullstep)
                {
                    step = 0;
                    rotateY = 0.0f;
                    transform.eulerAngles = new Vector3(0, rotateY, 0);
                    movector.x = speed;
                    movector.z = 0;
                    src.Play(); /////////////////////////////////////////////////////////////////////////////////////////////
                
                }

                if (step != fullstep)
                {
                motionizer.Move(movector);
                
                step++;
                    
                }
                else
                {
                    movector.x = 0;
                    movector.z = 0;
                }
            }
        }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Enemy"))
        {
            GameManager.life--;
            Hurt();
        }  
    }

    public void Hurt()
    {
        if(!alreadyHurt)
        {
            GameManager.isPlaying = false;
            alreadyHurt = true;

            if (GameManager.life <= 0) {
                GameObject.FindGameObjectWithTag("Result").GetComponent<Result>().Show(Result.GAME_OVER);
                Invoke("GameOver", 3);
            } 
            else
                Revive();
        }
        
    }

    private void Revive()
    {
        transform.position = initPosition;
        alreadyHurt = false;
        GameObject.FindGameObjectWithTag("Result").GetComponent<Result>().Show(Result.TRY_AGAIN);
        Invoke("GameOn", 3);
    }

    private void GameOn()
    {
        GameObject.FindGameObjectWithTag("Result").GetComponent<Result>().Hide();
        GameManager.isPlaying = true;

    }

    private void GameOver()
    {
        GameObject.FindGameObjectWithTag("Result").GetComponent<Result>().Hide();
        GameManager.Reset();
        GameManager.isPlaying = false;
        Destroy(GameObject.FindGameObjectWithTag("OSD"));
        SceneManager.LoadScene("Main Menu");
    }

    private void moveSound()
    {
        
    }

}
