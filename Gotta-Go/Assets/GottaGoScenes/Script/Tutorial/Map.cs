using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject TleftMost;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(Speed.map_speed, 0);
        TleftMost = GameObject.Find("TLeftBound");
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.x <= TleftMost.transform.position.x)
        {
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(Speed.map_speed, 0);
    }
}
