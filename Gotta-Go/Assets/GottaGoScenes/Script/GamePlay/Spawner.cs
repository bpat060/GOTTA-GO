using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
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
            rightMost = Instantiate(maps[0], this.transform.position, 
            Quaternion.identity);

            if(Random.Range(0,6) == 0)
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
        Instantiate(obstacles[Random.Range(0,obstacles.Length)],
            new Vector2(Random.Range(1,4) + rightMost.transform.position.x, 0.95f + rightMost.transform.position.y),
            Quaternion.identity, rightMost.transform);
    }

    void SpawnMiniPower()
    {
        float offsetX = Random.Range(1,4);
        Instantiate(minipowers[Random.Range(0,minipowers.Length)],
            new Vector2(Random.Range(1,4) + rightMost.transform.position.x, 3.0f + rightMost.transform.position.y),
            Quaternion.identity, rightMost.transform);

        Instantiate(platform, new Vector2(offsetX + rightMost.transform.position.x, 2.663252f + rightMost.transform.position.y),
            Quaternion.identity, rightMost.transform);
    }
}
