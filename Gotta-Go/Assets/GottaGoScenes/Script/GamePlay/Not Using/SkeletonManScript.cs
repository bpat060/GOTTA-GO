using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonManScript : MonoBehaviour
{
    public float playerSpeed;
    public float speedMultiplier;
    public float speedIncreaseMilestone;
    private float speedMiltestoneCount;
    private Rigidbody2D rb;
    private Vector2 playerDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        float directionY = Input.GetAxisRaw("Vertical");
        playerDirection = new Vector2(-7, directionY).normalized;
    }

    void FixedUpdate()
    {
        //if (transform.playerDirection.x > speedMiltestoneCount)
        //{
            //speedMiltestoneCount += speedIncreaseMilestone;
            //playerSpeed = playerSpeed + speedMultiplier;
        //}
        rb.velocity = new Vector2(0, playerDirection.y * playerSpeed);
    }
}
