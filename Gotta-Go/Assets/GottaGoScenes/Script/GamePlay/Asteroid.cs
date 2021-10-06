using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    //variables for the Asteroid obstacle
    Transform trans;
    private float restTime = 0;
    Rigidbody2D speed;
    
    // Start is called before the first frame update
    void Start()
    {
        trans = this.gameObject.transform;
        speed = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    /*void Update()
    {
        //lets the Asteroid obstacle move up and down
        restTime += Time.deltaTime;
        if(restTime <= 1.5)
        {
            trans.position = new Vector3(trans.position.x, trans.position.y + 0.01f, trans.position.z);
        }
        else if(restTime >= 1.5 && restTime <= 3)
        {
            trans.position = new Vector3(trans.position.x, trans.position.y - 0.01f, trans.position.z);
        }
        else
        {
            restTime = 0;
        }
    }*/

    void FixedUpdate() 
    {
        restTime += Time.deltaTime;
        /*if(restTime <= 1.5)
        {
            speed.velocity += new Vector2(0, 3);
        }
        else if(restTime >= 1.5 && restTime <= 3)
        {
            speed.velocity -= new Vector2(0, 3);
        }*/

        if(restTime <= 3)
        {
            trans.position = new Vector3(trans.position.x, trans.position.y + 0.05f, trans.position.z);
        }
        else if(restTime >= 3 && restTime <= 6)
        {
            trans.position = new Vector3(trans.position.x, trans.position.y - 0.05f, trans.position.z);
        }
        else
        {
            restTime = 0;
        }
    }

}
