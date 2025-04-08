using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovementControl : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float doubleJumpSpeed;
    [SerializeField] private AudioClip JumpSound;

    private Rigidbody2D rb;
    private Animator animator;
    private BoxCollider2D myFeet;

    private bool playerIsOnGround;
    private bool playerIsOnOneWayPlatform;
    private bool doubleJump;

    private bool isClimbing;
    private bool isJumping;
    private bool isFalling;
    private bool isDoubleJumping;
    private bool isDoubleFalling;

    private bool playerIsOnLadder;

    private float gravityScaleAtStart;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        myFeet = GetComponent<BoxCollider2D>();
        gravityScaleAtStart = rb.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfPlayerOnAir();
        ChangeDirection();
        Run();
        Jump();
        ClimbLadder();
        CheckIfPlayerIsOnGround();
        CheckIfPlayerIsOnLadder();
        SwitchJumpingAnimation();
        OneWayPlatformCheck();
    
    }

    void ChangeDirection()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(rb.linearVelocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            if(rb.linearVelocity.x > 0.1f)
            {
                transform.localRotation =  Quaternion.Euler(0, 0, 0);
            }

            if (rb.linearVelocity.x < -0.1f)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }

    void Run()
    {
        float x = Input.GetAxis("Horizontal");
        Vector2 movementVel = new Vector2(x * movementSpeed, rb.linearVelocity.y);
        rb.linearVelocity = movementVel;
        bool playerHasHorizontalSpeed = Mathf.Abs(rb.linearVelocity.x) > Mathf.Epsilon;
        animator.SetBool("Run", playerHasHorizontalSpeed);
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (playerIsOnGround)
            {
                SoundController.FindSoundController().PlaySound(JumpSound);
                animator.SetBool("Jump", true);
                Vector2 jumpVel = new Vector2(0f, jumpSpeed);
                rb.linearVelocity = Vector2.up * jumpVel;
                doubleJump = true;
            }
            else
            {
                if (doubleJump)
                {
                    SoundController.FindSoundController().PlaySound(JumpSound);
                    animator.SetBool("DoubleJump", true);
                    Vector2 doubleJumpVel = new Vector2(0f, doubleJumpSpeed);
                    rb.linearVelocity = Vector2.up * doubleJumpVel;
                    doubleJump = false;
                }
            }
        }
    }

    void ClimbLadder()
    {
        if (playerIsOnLadder)
        {
            float y = Input.GetAxis("Vertical");
            if (y > 0.1f || y < -0.1f )
            {
                animator.SetBool("Jump", false);
                animator.SetBool("Fall", false);
                animator.SetBool("DoubleJump", false);
                animator.SetBool("DoubleFall", false);
                animator.SetBool("Climb", true);
                playerIsOnGround = false;
                rb.gravityScale = 0f;
                Vector2 climbVel = new Vector2(rb.linearVelocity.x, y * movementSpeed);
                rb.linearVelocity = climbVel;
            }
            else if (y == 0f)
            {
                if(isJumping || isFalling || isDoubleJumping || isDoubleFalling || playerIsOnGround)
                {
                    animator.SetBool("Climb", false);
                }
                else
                {
                    animator.SetBool("Jump", false);
                    animator.SetBool("Fall", false);
                    animator.SetBool("DoubleJump", false);
                    animator.SetBool("DoubleFall", false);
                    animator.SetBool("Climb", true);   
                    playerIsOnGround = false;    
                    rb.gravityScale = 0f;
                    rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
                }
            }
 
        }
        else
        {
            animator.SetBool("Climb", false);
            rb.gravityScale = gravityScaleAtStart;
        }
    }

    void CheckIfPlayerIsOnGround()
    {
        playerIsOnGround = myFeet.IsTouchingLayers(LayerMask.GetMask("Ground")) || 
                           myFeet.IsTouchingLayers(LayerMask.GetMask("Platform") )||   
                           myFeet.IsTouchingLayers(LayerMask.GetMask("OneWayPlatform") );
        
        playerIsOnOneWayPlatform = myFeet.IsTouchingLayers(LayerMask.GetMask("OneWayPlatform"));
    }


    void CheckIfPlayerIsOnLadder()
    {
        playerIsOnLadder = myFeet.IsTouchingLayers(LayerMask.GetMask("Ladder"));
    }

    void SwitchJumpingAnimation()
    {
        animator.SetBool("Idle", false);

        if (animator.GetBool("Jump") == true)
        {
            if (rb.linearVelocity.y < 0f)
            {
                animator.SetBool("Jump", false);
                animator.SetBool("Fall", true);
            }
        }
        else if (playerIsOnGround)
        {
            animator.SetBool("Fall", false);
            animator.SetBool("Idle", true);
        }


        if (animator.GetBool("DoubleJump") == true)
        {
            if (rb.linearVelocity.y < 0f)
            {
                animator.SetBool("DoubleJump", false);
                animator.SetBool("DoubleFall", true);
            }
        }
        else if (playerIsOnGround)
        {
            animator.SetBool("DoubleFall", false);
            animator.SetBool("Idle", true);
        }
    }

    void OneWayPlatformCheck()
    {
        if(playerIsOnGround && gameObject.layer != LayerMask.NameToLayer("Player"))
        {
            gameObject.layer = LayerMask.NameToLayer("Player");
        }

        float playerY = Input.GetAxis("Vertical");

        if (playerIsOnOneWayPlatform && playerY < -0.1f)
        {
           gameObject.layer = LayerMask.NameToLayer("OneWayPlatform");
           Invoke("RestorePlayerLayer", 0.5f);
        }
    }

    void RestorePlayerLayer()
    {
        if(!playerIsOnGround && gameObject.layer != LayerMask.NameToLayer("Player"))
        {
            gameObject.layer = LayerMask.NameToLayer("Player");
        }
    }
    

    void CheckIfPlayerOnAir()
    {
        isJumping = animator.GetBool("Jump");
        isFalling = animator.GetBool("Fall");
        isDoubleJumping = animator.GetBool("DoubleJump");
        isDoubleFalling = animator.GetBool("DoubleFall");
        isClimbing = animator.GetBool("Climb");
    }
}
