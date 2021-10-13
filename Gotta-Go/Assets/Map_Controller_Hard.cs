using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_Controller_Hard : MonoBehaviour
{
    //variables needed for the map controller, controlls how the screen of the players device looks. 
    Rigidbody2D rb;
    GameObject leftMost;


    // Start is called before the first frame update
    void Start()
    {
        //setting variables
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(Speed_Controller.map_speed, 0);
        leftMost = GameObject.Find("LeftBound");
    }

    // Update is called once per frame
    void Update()
    {
        //destroys the Game Objects and Clones at Leftbound from the spawner
        if(this.transform.position.x <= leftMost.transform.position.x)
        {
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate() 
    {
        //updating the speed of the rigid body
        rb.velocity = new Vector2(Speed_Controller_Hard.map_speed,0);
    }
}
