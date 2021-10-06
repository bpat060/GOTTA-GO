using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    //variables for the spawner
    public GameObject[] maps;
    public GameObject[] obstacles;
    public GameObject[] minipowers;
    public GameObject platform;


    GameObject rightMost;
    public float spawnPosX;
    
    // Start is called before the first frame update
    void Start()
    {
        rightMost = GameObject.Find("GroundOne");
    }

    // Update is called once per frame
    void Update()
    {
        if(rightMost.transform.position.x <= spawnPosX)
        {
            //to spawn the "new" Ground Clone
            rightMost = Instantiate(maps[0], this.transform.position, 
            Quaternion.identity);


            //to Control the Random Range of Game Object
            //For example, if Random.Range(0.4) that means, 1/4(25%) will spawn Minipower, and 3/4(75%) will spawn Obstacles
            if(Random.Range(0,8) == 0)
            {
                SpawnMiniPower();
            }
            else
            {
                SpawnObstacle();
            }
        }
    }

    void SpawnObstacle()
    {
        //to control the Position of the Random Obstacles spawning
        Instantiate(obstacles[Random.Range(0,obstacles.Length)],
            new Vector2(Random.Range(1,4) + rightMost.transform.position.x, 2.0f + rightMost.transform.position.y),
            Quaternion.identity, rightMost.transform);
    }

    void SpawnMiniPower()
    {
        //to control the Position of Minipowers and Platforms spawning
        float offsetX = 1;//Random.Range(1,2);
        Instantiate(minipowers[Random.Range(0,minipowers.Length)],
            new Vector2(Random.Range(1,2) + rightMost.transform.position.x, 4.0f + rightMost.transform.position.y),
            Quaternion.identity, rightMost.transform);

        Instantiate(platform, new Vector2(offsetX + rightMost.transform.position.x, 3.663252f + rightMost.transform.position.y),
            Quaternion.identity, rightMost.transform);
    }
}
