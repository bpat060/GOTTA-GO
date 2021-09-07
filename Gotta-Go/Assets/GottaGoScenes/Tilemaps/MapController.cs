using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    GameObject leftMost;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, 0);
        leftMost = GameObject.Find("LeftBound");
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.x <= leftMost.transform.position.x)
        {
            Destroy(this.gameObject);
        }
    }
}
