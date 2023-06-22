using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    //Necessary Components
    private Rigidbody2D rb;
    private CollisionChecker collisionChecker;
    
    //Player Data
    private float jumpMaxHeight = 5f;
    

    //Coyote Timer
    private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;

    //Jump Buffer Timer
    private float jumpBufferTime = 1f;
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
            rb.velocity = new Vector2(rb.velocity.x, jumpMaxHeight);
            coyoteTimeCounter = 0f;
        }

        if (context.canceled && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y/2);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        CoyoteTimeCheck();
        jumpBufferTimeCounter -= Time.deltaTime;
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
    
    
}
