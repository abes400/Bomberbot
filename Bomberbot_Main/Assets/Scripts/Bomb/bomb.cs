using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bomb : MonoBehaviour
{
    public float wait;
    // Start is called before the first frame update
    public GameObject model;
    public float rotateSpeed;
    Vector3 rotationVector;
    Transform rotationOfBomb;
    CapsuleCollider collider;
    public bool isTouching = true;
    GameObject player;
    public GameObject explosion;
    AudioSource src;

    void Start()
    {
        rotationVector = new Vector3(0, 1, 0);
        rotationOfBomb = transform.GetChild(0).gameObject.transform; 
    }

    public void Detonate()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
        collider = gameObject.GetComponent<CapsuleCollider>();
        collider.isTrigger = true;
        src = GetComponent<AudioSource>();
        src.Play();
        Invoke("Explosion", 3);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            collider.isTrigger = false;
            isTouching = false;
            player = null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        player = other.gameObject;
    }

    private void Explosion()
    {
        if (GameManager.isPlaying)
        {
            collider.isTrigger = true;

            GameObject tempExplode;

            RaycastHit hit;
            transform.eulerAngles = new Vector3(0, 0, 0);

            tempExplode = Instantiate(explosion);
            tempExplode.transform.position = transform.position;
            tempExplode.GetComponent<explosion>().initiate();

            for (float i = 0.0f; i <= 270.0f; i += 90.0f)
            {
                


                transform.eulerAngles = new Vector3(0, i, 0);
                if (Physics.Raycast(transform.position, transform.forward, out hit, 2f)) //1.46f => sweet spot
                {
                    tempExplode = Instantiate(explosion);
                    tempExplode.transform.position = hit.transform.position;
                    tempExplode.GetComponent<explosion>().initiate();

                } else
                {
                    tempExplode = Instantiate(explosion);
                    tempExplode.transform.position = transform.position + 2*transform.forward;
                    tempExplode.GetComponent<explosion>().initiate();
                }

                tempExplode = Instantiate(explosion);
                tempExplode.transform.position = transform.position + transform.forward;
                tempExplode.GetComponent<explosion>().initiate();

            }

            if (isTouching)
            {
                GameManager.life --;
                player.GetComponent<move>().Hurt();
            }
            GameManager.src.Play();
            gameObject.SetActive(false);
        } else
            StartCoroutine(asyncExplosion());

    }

    IEnumerator asyncExplosion()
    {
        yield return !GameManager.isPlaying;
        Explosion();
    }

    // Update is called once per frame
    void LateUpdate()
    {   if(GameManager.isPlaying)
            rotationOfBomb.Rotate(rotationVector);
        
    }
}
