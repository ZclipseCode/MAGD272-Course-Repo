using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootDemo : MonoBehaviour
{
    public GameObject bullet;
    public Transform shootPoint;
    public KeyCode shootButton;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(shootButton))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        //what, where, rotation (facing?), parented?
        Instantiate(bullet, shootPoint.position, transform.rotation, null);
    }
}
