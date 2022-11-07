using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitfallDeath : MonoBehaviour
{
    void Update()
    {
        if (gameObject.transform.position.y <= -6.5)
        {
            gameObject.GetComponent<PlayerHealth>().TakeDamage(gameObject.GetComponent<PlayerHealth>().GetCurrentHealth());
        }
    }
}
