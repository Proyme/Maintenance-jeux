using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterCollision : MonoBehaviour
{
    public PlayerHealth playerHealth;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with a specific tag
        if (collision.gameObject.name == "Player")
        {
            // Do something (e.g. play a sound)
            Debug.Log("Collided with player!");
            playerHealth.Die();
        }
    }
}
