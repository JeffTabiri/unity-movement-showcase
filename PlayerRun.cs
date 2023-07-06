using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Class responsible for the managing the player run.
/// </summary>
public class PlayerRun : MonoBehaviour
{
    //Necessary Components
    private Rigidbody2D rb;
    
    public Rigidbody2D Rb
    {
        get
        {
            return rb;
        }
        private set
        {
            rb = value;
        }
    }
    
    //Player Data
    private float runMaxSpeed = 7f;
    
    //Player Move Input
    private Vector2 moveInput;
    
    
    [SerializeField]
    private bool isFacingRight = true;


    public bool IsFacingRight
    {
        get
        {
            return isFacingRight;
        }
        private set
        {
            if (isFacingRight != value)
            {
                transform.localScale *= new Vector2(-1, 1);
            }
            
            isFacingRight = value;
        }
    }
    
    
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(moveInput.x*runMaxSpeed, rb.velocity.y);
        SetFaceDirection();
    }

    /// <summary>
    /// Registers analog input from the user and assigns it to variable.
    /// Ranges from -1 to 1, and represents the direction from left to right. 
    /// </summary>
    /// <param name="context"></param>
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

   
    /// <summary>
    /// Sets player face direction to the boolean value.
    /// </summary>
    private void SetFaceDirection()
    {
        if (moveInput.x > 0 && !isFacingRight)
        {
            IsFacingRight = true;
        }
        else if (moveInput.x < 0 && isFacingRight)
        {
            IsFacingRight = false;
        }
    }
    
}
    
