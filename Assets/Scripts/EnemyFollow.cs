using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public int damageOnCollision = 5;

    public float Hitpoints;
    public float maxHealth = 20;
    public HealthBarBehaviour Healthbar;

    [SerializeField] private float speed = 1;

    private Transform target;

    void Awake()
    {
        target = FindObjectOfType<Movement>().transform;
    }

    void Start()
    {
        Hitpoints = maxHealth;
        Healthbar.SetHealth(Hitpoints, maxHealth);
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

            Destroy(gameObject);
        }
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
