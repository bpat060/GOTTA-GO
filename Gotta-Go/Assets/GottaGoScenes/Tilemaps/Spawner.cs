using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] maps;
    GameObject rightMost;
    public float spawnPosX;
    
    // Start is called before the first frame update
    void Start()
    {
        rightMost = GameObject.Find("PlatformThree");
    }

    // Update is called once per frame
    void Update()
    {
        if(rightMost.transform.position.x <= spawnPosX)
        {
            rightMost = Instantiate(maps[0], this.transform.position, Quaternion.identity);
        }
    }
}
