using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpSpeed;
    Rigidbody2D rb;
    Animator anim;


    //Dodge - change the BoxCollider2D
    private BoxCollider2D box;
    private float originalOffsetY = -0.0545001f;
    private float originalSizeY = 1.163999f;

    private float dodgeTime = 0;
    private float jumpTime = 0;

    public Transform checkPoint;
    public float checkRadius;
    public LayerMask groundMask;

    public bool isOnGround;
    public bool isOnJump = false;
    public static bool hasShield = false;

    public GameManager1 gameManager1;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        isOnGround = Physics2D.OverlapCircle(checkPoint.position, checkRadius, groundMask);
        anim.SetBool("isOnGround", isOnGround);
        rb.freezeRotation = true;

        /*if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !Input.GetKeyDown(KeyCode.Z))
        {
            rb.velocity += new Vector2(0, jumpSpeed);
        }

        if(Input.GetKeyDown(KeyCode.Z) && isOnGround && !Input.GetKeyDown(KeyCode.Space))
        {
            box.offset = new Vector2(box.offset.x, -0.4f);
            box.size = new Vector2(box.size.x, 0.5f);
            anim.SetBool("isDodge", true);
        }
        else if(Input.GetKeyUp(KeyCode.Z))
        {
            box.offset = new Vector2(box.offset.x, originalOffsetY);
            box.size = new Vector2(box.size.x, originalSizeY);
            anim.SetBool("isDodge", false);
        }*/

        if(jumpTime > 0 && isOnGround)
        {
            rb.velocity += new Vector2(0, jumpSpeed);
            isOnJump = false;
        }
        else if(jumpTime <= 0 && !isOnGround)
        {
            isOnJump = true;
        }
        
        if(dodgeTime > 0 && isOnGround)
        {
            box.offset = new Vector2(box.offset.x, -0.4f);
            box.size = new Vector2(box.size.x, 0.5f);
            anim.SetBool("isDodge", true);
        }
        else if(dodgeTime <= 0 || !isOnGround)
        {
            box.offset = new Vector2(box.offset.x, originalOffsetY);
            box.size = new Vector2(box.size.x, originalSizeY);
            anim.SetBool("isDodge", false);
            dodgeTime = 0;
        }

    }

    private void FixedUpdate() 
    {
        if(dodgeTime > 0)
        {
            dodgeTime -= Time.deltaTime;
        }
        if(jumpTime > 0)
        {
            jumpTime -= Time.deltaTime;
        }
    }

    public void Jump()
    {
        jumpTime = 0.5f;
        isOnJump = false;
    }

    public void Dodge()
    {
        dodgeTime = 0.5f;
    }


    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.CompareTag("Obstacle") && !hasShield)
        {
            gameManager1.RestartGame();
        }

        if(collision.CompareTag("MiniPower"))
        {
            Speed_Controller.Accelerate();
            Destroy(collision.gameObject);
        }
    }

  //  void Dead() 
  //  {
  //      Destroy(this.gameObject);
  //  }

}
