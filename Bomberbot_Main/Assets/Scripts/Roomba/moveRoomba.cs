using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class moveRoomba : MonoBehaviour
{
    CharacterController motionizer;
    public Vector3 movector;
    public float speed = 0.01f;
    public int step;
    public int fullstep = 93;
    int dir = 0;
    public int randomTimeout = 100;
    bool[] available = { false, false, false, false };
    
    // Start is called before the first frame update
    void Start()
    {
        motionizer = GetComponent<CharacterController>();
        step = fullstep;
        movector = new Vector3(speed, 0, 0);
        transform.Rotate(new Vector3(0, dir, 0));

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.isPlaying) // GameManager.isPlaying
        {
            movector = transform.forward * speed;

            RaycastHit hit2;
            if (Physics.Raycast(transform.position, transform.forward, out hit2, 0.5f))
            {
                if (hit2.transform.gameObject.CompareTag("Player"))
                {
                    GameManager.life--;
                    hit2.transform.gameObject.GetComponent<move>().Hurt();
                }
                dir++;
            }
            

            if (step != fullstep)
            {
                motionizer.Move(movector);
                step++;
            }
            else
            {
                RaycastHit hit;
                available[0] = Physics.Raycast(transform.position, transform.forward, out hit, 0.5f) ? false : true;
                available[1] = Physics.Raycast(transform.position, transform.right, out hit, 0.5f) ? false : true;
                available[2] = Physics.Raycast(transform.position, -transform.forward, out hit, 0.5f) ? false : true;
                available[3] = Physics.Raycast(transform.position, -transform.right, out hit, 0.5f) ? false : true;
                

                for(int count = 0; count <= randomTimeout; count++)
                {
                    int i = Random.Range(0, 3);
                    if (available[i])
                    {
                        dir = 90 * i;
                        break;
                    }

                    if(count == randomTimeout)
                    {
                        //Debug.Log("Random Timeout");
                        for (i = 0; i < 4; i++)
                        {
                            if (i == 0) dir = 0;
                            if (available[i]) break;
                            dir += 90;
                        }
                    }
                }

                //Debug.Log(dir == 0 ? "Ön" : dir == 90 ? "Sað" : dir == 180 ? "arka" : "sol");
                step = 0;
                transform.Rotate(new Vector3(0, dir, 0));

            }
        }
    }

    private void OnCollisionEnter(Collision collision) /////MALFONKTA SÝL
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //Debug.Log("hhh");
            Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), collision.gameObject.GetComponent<Collider>());
            Physics.IgnoreCollision(gameObject.GetComponent<CharacterController>(), collision.gameObject.GetComponent<CharacterController>());
        }
            
    }


    private void OnTriggerEnter(Collider other)/////MALFONKTA SÝL
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //Debug.Log("hhh");
            Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), other.gameObject.GetComponent<Collider>());
            Physics.IgnoreCollision(gameObject.GetComponent<CharacterController>(), other.gameObject.GetComponent<CharacterController>());
        }

    }

}


/*BACKUP

/*
            if (dir % 4 == 0)
            {
                rotateY = -90.0f;
                transform.eulerAngles = new Vector3(0, rotateY, 0);
                movector.x = 0;
                movector.z = speed;
            }
            else if (dir % 4 == 1)
            {
                rotateY = 90.0f;
                transform.eulerAngles = new Vector3(0, rotateY, 0);
                movector.x = 0;
                movector.z = -speed;
            }
            else if (dir % 4 == 2)
            {
                rotateY = 180.0f;
                transform.eulerAngles = new Vector3(0, rotateY, 0);
                movector.x = -speed;
                movector.z = 0;
            }
            else if (dir % 4 == 3)
            {

                rotateY = 0.0f;
                transform.eulerAngles = new Vector3(0, rotateY, 0);
                movector.x = speed;
                movector.z = 0;
            }


            if (step != fullstep)
            {
                motionizer.Move(movector);
                step++;
            }


             else
            {

                if (changedir % mmod == 0)
                {
                    dir = Random.Range(0, 4);

                    RaycastHit hit2;
                    if (Physics.Raycast(transform.position, transform.forward, out hit2, 0.5f))
                    {
                        if (hit2.transform.gameObject.CompareTag("Player"))
                        {
                            GameManager.life--;
                            hit2.transform.gameObject.GetComponent<move>().Hurt(); 
                        }
                        dir++;
                    }
                    else
                    {
                        step = 0;
                    }

                }
                changedir++;
            }*/
//Debug.Log(dir);