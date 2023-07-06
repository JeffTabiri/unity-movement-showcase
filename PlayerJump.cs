using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    //Necessary Components
    private Rigidbody2D rb;
    private CollisionChecker collisionChecker;
    
    /*
     * Player Jump State
    */
    [SerializeField]
    private bool hasPlayerReachedPeak = false;
    
    [SerializeField]
    private bool isPlayerFalling = false;
    
    [SerializeField]
    private bool isPlayerGoingUp = false;
    
    /*
     * Player Jump Data
     */
    [SerializeField]
    private float jumpPower = 6f;
    
    [SerializeField]
    private float maxFallSpeed = 10f;
    
    [SerializeField]
    private float fallGravityMultiply = 4;
    
    //Coyote Timer
    private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;

    //Jump Buffer Timer
    private float jumpBufferTime = 0.2f;
    private float jumpBufferTimeCounter;
    
    
    //Find necessary components
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        collisionChecker = GetComponent<CollisionChecker>();
    }

    /// <summary>
    /// Jump script, which is responsible for applying for in the y axis. 
    /// </summary>
    /// <param name="context">
    /// Which is responsible for listening for keys which starts the jump method. 
    /// </param>
    public void OnJump(InputAction.CallbackContext context)
    {
       
        jumpBufferTimeCounter = jumpBufferTime;
        
        if (jumpBufferTimeCounter > 0 && coyoteTimeCounter > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            coyoteTimeCounter = 0f;
            jumpBufferTimeCounter = 0f;
        }

        if (context.canceled)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y*0.5f); 
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CoyoteTimeCheck();
        CheckJumpApex();
        CheckIfPlayerFalls();
        CheckIfPlayerGoingUp();
        
        /*
        if (collisionChecker.isGrounded)
        {
            hasPlayerReachedPeak = false;
        }

        if (hasPlayerReachedPeak && !collisionChecker.isWalled)
        {
            rb.gravityScale = fallGravityMultiply;
        }
        
        if (isPlayerFalling && !collisionChecker.isWalled)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Max(rb.velocity.y, -maxFallSpeed));
        }

        if (collisionChecker.isGrounded)
        {
            rb.gravityScale = 1;
        }
        */
    }

    /// <summary>
    /// Coyote Time creates a bigger jump window for the player.
    /// </summary>
    private void CoyoteTimeCheck()
    {
        if (collisionChecker.isGrounded)
        {
            coyoteTimeCounter = coyoteTime; //Reset the coyoteCounter
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime; //Reduce the counter whenever player is not grounded. 
        }
    }
    
    
    
    /**
     * Checks when the player reaches its highest velocity.
     */
    private void CheckJumpApex()
    {
        if (rb.velocity.y < 0 && !hasPlayerReachedPeak)
        {
            hasPlayerReachedPeak = true;
        }
    }
    
    

    /**
     * Checks if player is falling.
     * Returns a boolean value of its state. 
     */
    private void CheckIfPlayerFalls()
    {
        if (rb.velocity.y < 0)
        {
            isPlayerFalling = true;
        }
        else
        {
            isPlayerFalling = false;
        }
    }

    /**
     * Checks if player character is going upwards.
     * Returns a boolean value of its state. 
     */
    private void CheckIfPlayerGoingUp()
    {
        if (rb.velocity.y > 0)
        {
            isPlayerGoingUp = true;
        }
        else
        {
            isPlayerGoingUp = false;
        }
    }
    
}
