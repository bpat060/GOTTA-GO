using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //varaibles of the player class
    public float jumpHeight;
    Rigidbody2D rb;
    Animator anim;

    //Dodge - change the BoxCollider2D
    //change player Size to half of that dodge obstacles
    private BoxCollider2D box;
    private float originalOffsetY = -0.0545001f;
    private float originalSizeY = 1.163999f;

    //set Time in between jump and dodge
    private float dodgeTime = 0;
    private float jumpTime = 0;

    //set for check point
    public Transform checkPoint;
    public float checkRadius;
    public LayerMask groundMask;

    //Player status: is on ground/jump/hasShield or not
    public bool isOnGround;
    public bool isOnJump = false;
    public static bool hasShield = false;

    //link to GameManager1
    public GameManager1 gameManager1;

    //Score System
    private int totalScore;
    //Player get 1 point per second
    private int surviveScore = 1;
    private Text scoreText;
    private float surviveTime;
    //Player get 10 points when Player get the Cherry
    private int scorenerScore = 10;

    // Start is called before the first frame update
    void Start()
    {
        //setting the rigid body, player animation and collider components
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
        scoreText = GameObject.Find("Score").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //freezes the Rotation, and sets the boolean for Jump and Dodge function and animator
        isOnGround = Physics2D.OverlapCircle(checkPoint.position, checkRadius, groundMask);
        anim.SetBool("isOnGround", isOnGround);
        rb.freezeRotation = true;

        scoreText.text = totalScore.ToString();
    }

    private void FixedUpdate() 
    {
        //Desktop Player Controls
        /*if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !Input.GetKeyDown(KeyCode.Z) && jumpTime > 0)
        {
            rb.velocity += new Vector2(0, jumpHeight);
            isOnJump = true;
        }

        if(!isOnGround && jumpTime < 0)
        {
            isOnJump = false;
        }

        if(Input.GetKeyDown(KeyCode.Z) && isOnGround && !Input.GetKeyDown(KeyCode.Space) && dodgeTime > 0)
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
        }*/
        
        //when the jump button is clicked, this method plays the jump animation.
        if(jumpTime > 0 && isOnGround)
        {
            rb.velocity += new Vector2(0, jumpHeight);
            isOnJump = true;
        }
        else if(jumpTime <= 0 && !isOnGround)
        {
            isOnJump = false;
        }
        
        //when the dodge button is clicked, this method plays the dodge animation and changes the box collider.
        if(dodgeTime > 0 && isOnGround)
        {
            box.offset = new Vector2(box.offset.x, -0.4f);
            box.size = new Vector2(box.size.x, 0.5f);
            anim.SetBool("isDodge", true);
        }
        //when dodge clicked while player is in the air this method changes the box Collider to normal
        else if(dodgeTime <= 0 || !isOnGround)
        {
            box.offset = new Vector2(box.offset.x, originalOffsetY);
            box.size = new Vector2(box.size.x, originalSizeY);
            anim.SetBool("isDodge", false);
            dodgeTime = 0;
        }
        
        //time updates when the player dodges or jumps everytime
        if(dodgeTime > 0)
        {
            dodgeTime -= Time.deltaTime;
        }
        if(jumpTime > 0)
        {
            jumpTime -= Time.deltaTime;
        }

        surviveTime += Time.deltaTime;
        if(surviveTime > 1)
        {
            totalScore += surviveScore;
            surviveTime = 0;
        }

    }

    public void Jump()
    {
        //setting the jumptime and boolean. 
        jumpTime = 0.5f;
        isOnJump = false;
    }

    public void Dodge()
    {
        //setting the dodge time
        dodgeTime = 0.5f;
    }

    //function for when the player collides with another object
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.CompareTag("Obstacle") && !hasShield)
        {
            //if collision with an obstacle, player dies and game restarts
            gameManager1.RestartGame();
        }

        if(collision.CompareTag("MiniPower"))
        {
            //if collision with a power up, player speed increases and is temporary invincible to obstacle collisions
            Speed_Controller.Accelerate();
            Destroy(collision.gameObject);
        }
        //collision with the platform is not needed as it does not do anything anyways.

        if(collision.CompareTag("Scorener"))
        {
            //if collision with a Cherry, player total score +10
            totalScore += scorenerScore;
            Destroy(collision.gameObject);
        }
    }

}
