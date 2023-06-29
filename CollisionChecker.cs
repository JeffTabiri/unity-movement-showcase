using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionChecker : MonoBehaviour
{
    private PlayerRun playerRun;
    
    [SerializeField] 
    private bool isGround;

    [SerializeField] 
    private bool isFacingWall;

    private float groundDistance = 0.05f;
    
    private float wallDistance = 0.05f;

    private RaycastHit2D[] hits = new RaycastHit2D[5];
    private RaycastHit2D[] wallhits = new RaycastHit2D[5];

    private ContactFilter2D castFilterGround;

    private ContactFilter2D castFilterWall;
    
    public bool isGrounded
    {
        get
        {
            return isGround;
        }
        private set
        {
            isGround = value;
        }

    }

    public bool isWalled
    {
        get
        {
            return isFacingWall;
        }
        private set
        {
            isFacingWall = value;
        }

    }
    
    //Components
    private CapsuleCollider2D playerCollider;



    // Start is called before the first frame update
    void Awake()
    {
        playerCollider = GetComponent<CapsuleCollider2D>();
        playerRun = GetComponent<PlayerRun>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = playerCollider.Cast(Vector2.down, castFilterGround, hits, groundDistance) > 0.01f;
        DetectWall();
    }


    public void DetectWall()
    {
        if (playerRun.IsFacingRight)
        {
            isWalled = playerCollider.Cast(Vector2.right, castFilterWall, wallhits, wallDistance) > 0.01f;
        }
        else if (!playerRun.IsFacingRight)
        {
            isWalled = playerCollider.Cast(Vector2.left, castFilterWall, wallhits, wallDistance) > 0.01f;
        }
    }   

}
