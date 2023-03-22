using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public int damageOnCollision = 5;

    public float Hitpoints;
    public float MaxHealth = 60;
    public HealthBarBehaviour Healthbar;

    public float speed;
    public Transform[] waypoints;

    public SpriteRenderer graphics;
    private Transform target;
    private int destPoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        target = waypoints[0];

        Hitpoints = MaxHealth;
        Healthbar.SetHealth(Hitpoints, MaxHealth);
    }

    public void TakeHit(float damage)
    {
        Hitpoints -= damage;

        if (Hitpoints <= 0)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) < 0.2f) // le float sert a faire changer de direction avant d'etre arrive sur le pts
        {
            destPoint = (destPoint + 1) % waypoints.Length;
            target = waypoints[destPoint];
            graphics.flipX = !graphics.flipX;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damageOnCollision);
        }
    }
}
