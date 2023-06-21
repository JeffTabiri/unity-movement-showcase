using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionChecker : MonoBehaviour
{

    [SerializeField] private bool isGround;

    [SerializeField] private bool isFacingWall;

    private float groundDistance = 0.05f;
    
    private float wallDistance = 0.05f;

    private ContactFilter2D castFilterGround;

    private ContactFilter2D castFilterWall;

    private RaycastHit2D[] groundHits = new RaycastHit2D[3];

    private RaycastHit2D[] wallHits = new RaycastHit2D[3];

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
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = playerCollider.Cast(Vector2.down, castFilterGround, groundHits, groundDistance) > 0;
         
        isWalled = playerCollider.Cast(Vector2.right, castFilterWall, wallHits, wallDistance) > 0;
        Debug.DrawLine(playerCollider.transform.position, Vector2.right);
        Debug.DrawLine(playerCollider.transform.position, Vector2.down);
    }
    
    
}
