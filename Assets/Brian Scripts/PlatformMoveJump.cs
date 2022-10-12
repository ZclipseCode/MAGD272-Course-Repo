using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoveJump : MonoBehaviour
{
    //Capture input
    //Move left and right
    //Jump
    //Check if grounded
    bool isGrounded = false; //bools by default are false
    Rigidbody2D rb;
    [SerializeField] private float speed = 3f;
    [SerializeField] private float jumpForce = 3f;
    [SerializeField] private KeyCode jumpButton;
    float horizontal = 0;
    [SerializeField] Transform groundCheckTransform;
    [SerializeField] float groundCheckRadius = 3f;
    [SerializeField] LayerMask groundCheckLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Capture input
        horizontal = Input.GetAxis("Horizontal");

        //Move left and right
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        //Check if ground
        isGrounded = Grounded();

        //Jump
        if (Input.GetKeyDown(jumpButton) && isGrounded)
        {
            rb.velocity = new Vector2(horizontal * speed, jumpForce);
        }
    }

    public bool Grounded()
    {
        return Physics2D.OverlapCircle(groundCheckTransform.position, groundCheckRadius, groundCheckLayer);
    }
}
