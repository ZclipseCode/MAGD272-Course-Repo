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
    [SerializeField] int maxJumps = 2;
    [SerializeField] int jumpCount = 0;

    //sprite flip
    bool facingRight = true; //starts facing right

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
        if (Input.GetKeyDown(jumpButton) && (isGrounded || jumpCount < maxJumps))
        {
                rb.velocity = new Vector2(horizontal * speed, jumpForce);
                jumpCount++;
        }

        //Adjust jump
        if (Input.GetKeyUp(jumpButton) && rb.velocity.y > 0){
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y * 0.5f);
        }

        //flip
        flip();
    }

    public bool Grounded()
    {
        if (Physics2D.OverlapCircle(groundCheckTransform.position, groundCheckRadius, groundCheckLayer))
        {
            jumpCount = 0;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void flip()
    {
        if ((horizontal < 0 && facingRight) || (horizontal > 0 && !facingRight))
        {
            facingRight = !facingRight;
            transform.Rotate(new Vector3(0, 180, 0));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bomb"))
        {
            Debug.Log($"Collided with {collision.gameObject.name}");
            collision.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"Collided with {collision.gameObject.name} with a isTriggerCollider");
        Destroy(collision.gameObject);
    }
}
