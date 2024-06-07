using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titaniumCrate : MonoBehaviour
{
    public bool colliding;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Player")
        {
            colliding = true;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
