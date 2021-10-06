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
    void FixedUpdate() 
    {
        restTime += Time.deltaTime;
        if(restTime <= 3)
        {
            trans.position = new Vector3(trans.position.x, trans.position.y + 0.03f, trans.position.z);
        }
        else if(restTime >= 3 && restTime <= 6)
        {
            trans.position = new Vector3(trans.position.x, trans.position.y - 0.03f, trans.position.z);
        }
        else
        {
            restTime = 0;
        }
    }

}
