using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDemo : MonoBehaviour
{
    [SerializeField] private int currentHealth = 100;

    void Start()
    {
        
    }

    public void takeDamage(int value)
    {
        currentHealth -= value;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
