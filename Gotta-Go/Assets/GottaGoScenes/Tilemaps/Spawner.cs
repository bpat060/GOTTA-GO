using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] maps;
    GameObject rightMost;
    public float spawnPosX;
    GameObject grid;
    
    // Start is called before the first frame update
    void Start()
    {
        rightMost = GameObject.Find("TilemapTwo");
        grid = GameObject.Find("Grid");
    }

    // Update is called once per frame
    void Update()
    {
        if(rightMost.transform.position.x <= spawnPosX)
        {
            Vector2 pos = this.transform.position;
            rightMost = Instantiate(maps[0], new Vector2(pos.x, pos.y + Random.Range(1, 3)), Quaternion.identity, grid.transform);
        }
    }
}
