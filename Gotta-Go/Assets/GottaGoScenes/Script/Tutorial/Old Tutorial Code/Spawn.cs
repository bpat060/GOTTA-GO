using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawn : MonoBehaviour
{
    public GameObject[] Tmaps;
    public GameObject[] Tobstacles;
    public GameObject[] Tminipowers;
    public GameObject Tplatform;


    GameObject TrightMost;
    public float TspawnPosX;

    // Start is called before the first frame update
    void Start()
    {
        TrightMost = GameObject.Find("TGroundOne");
    }

    // Update is called once per frame
    void Update()
    {
        if (TrightMost.transform.position.x <= TspawnPosX)
        {
            TrightMost = Instantiate(Tmaps[0], this.transform.position,
            Quaternion.identity);

            if (Random.Range(0, 10) == 0)
            {
                TSpawnMiniPower();
            }
            else
            {
                TSpawnObstacle();
            }
        }
    }

    void TSpawnObstacle()
    {
        Instantiate(Tobstacles[Random.Range(0, Tobstacles.Length)],
            new Vector2(Random.Range(1, 4) + TrightMost.transform.position.x, 2.0f + TrightMost.transform.position.y),
            Quaternion.identity, TrightMost.transform);
    }

    void TSpawnMiniPower()
    {
        float offsetX = Random.Range(1, 4);
        Instantiate(Tminipowers[Random.Range(0, Tminipowers.Length)],
            new Vector2(Random.Range(1, 2) + TrightMost.transform.position.x, 4.0f + TrightMost.transform.position.y),
            Quaternion.identity, TrightMost.transform);

        Instantiate(Tplatform, new Vector2(offsetX + TrightMost.transform.position.x, 3.663252f + TrightMost.transform.position.y),
            Quaternion.identity, TrightMost.transform);
    }
}
