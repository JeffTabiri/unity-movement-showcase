using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerClimb : MonoBehaviour
{
    //Necessary Components
    private Rigidbody2D rb;
    private CollisionChecker collisionChecker;

    [SerializeField]
    private bool isWallSliding = false;
    
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        collisionChecker = GetComponent<CollisionChecker>();
    }


    public void WallSlide()
    {
        if (!collisionChecker.isGrounded && collisionChecker.isWalled) ;
            isWallSliding = true;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -40, float.MaxValue));
        }
    }
