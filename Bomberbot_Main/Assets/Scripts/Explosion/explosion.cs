using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{

    public void initiate()
    {
        GetComponent<ParticleSystem>().Play();
        Invoke("kill", 1);
    }

    // Update is called once per frame
    void kill()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle")) Destroy(gameObject);

        if (other.transform.tag == "Crate")
        {
            other.transform.gameObject.SetActive(false);
            GameManager.crateCount--;
            GameManager.score += 10;
            GameManager.addedScore += 10;

        }
        else if (other.transform.tag == "Enemy")
        {
            other.transform.gameObject.SetActive(false);
            GameManager.roombaCount--;
            GameManager.score += 20;
            GameManager.addedScore += 20;
        }
        if (other.transform.tag == "Playerbody")
        {
            GameManager.life--;
            other.transform.parent.gameObject.transform.parent.gameObject.GetComponent<move>().Hurt();
        }

        
    }



}
