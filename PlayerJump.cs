using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody2D rb;
    private CollisionChecker collisionChecker;
    private float jumpMaxHeight = 10f;
    

    private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;
    
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        collisionChecker = GetComponent<CollisionChecker>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started && coyoteTimeCounter > 0) 
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpMaxHeight);
            coyoteTimeCounter = 0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        CoyoteTimeCheck();
        
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
