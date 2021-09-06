using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpSpeed;
    Rigidbody2D rb;
    Animator anim;


    public Transform checkPoint;
    public float checkRadius;
    public LayerMask groundMask;

    public bool isOnGround;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isOnGround = Physics2D.OverlapCircle(checkPoint.position, checkRadius, groundMask);
        anim.SetBool("isOnGround", isOnGround);
        rb.rotation = 0;

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            rb.velocity += new Vector2(0, jumpSpeed);
        }
    }
}
