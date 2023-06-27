using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Class responsible for the managaging the player run.
/// </summary>
public class PlayerRun : MonoBehaviour
{
    //Necessary Components
    private Rigidbody2D rb;
    private Vector2 moveInput;
    
    
    //Player Data
    private float runMaxSpeed = 7f;
    
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

    //Responsible for reading input from player.
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

    }

    //Responsible for adjusting the the facing direction to the character.
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
