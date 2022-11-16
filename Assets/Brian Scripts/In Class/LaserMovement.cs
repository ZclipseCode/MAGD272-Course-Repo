using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMovement : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed; //* -1 to reverse direction
    }

    void Start()
    {
       
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }
}
