using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyFollow : MonoBehaviour
{
    public int damageOnCollision = 5;

    public float Hitpoints;
    public float maxHealth = 20;

    public AIPath aiPath;

    void Start()
    {
        Hitpoints = maxHealth;
    }

    public void TakeHit(float damage)
    {
        Hitpoints -= damage;

        if (Hitpoints <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damageOnCollision);

            Destroy(transform.parent.gameObject);
            Destroy(gameObject);
        }
    }

    public void Update()
    {
        if(aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
