using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    Transform trans;
    private float restTime = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        trans = this.gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //let the Asteroid obstacle can move up and down
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
    }
}
