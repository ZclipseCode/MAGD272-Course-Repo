using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodingIntro : MonoBehaviour
{
    Rigidbody2D rb;
    float hor, ver;
    [SerializeField] private float speedMult = 2;
    [SerializeField] private float jump = 1000;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        hor = Input.GetAxisRaw("Horizontal");
        ver = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(hor * speedMult, rb.velocity.y);

        if(Mathf.Abs(ver) > 0 && rb.velocity.y < jump)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(new Vector2(0, ver * jump));
        }
    }
}
