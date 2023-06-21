using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody2D rb;
    private float jumpMaxHeight = 10f;
    
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpMaxHeight);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
