using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public int damageOnCollision = 5;

    public int MaxHealth = 60;
    public int CurrentHealth;
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

        CurrentHealth = MaxHealth;
        Healthbar.SetHealth(CurrentHealth, MaxHealth);
    }

    public void TakeHit(int damage)
    {
        CurrentHealth -= damage;

        Debug.Log(CurrentHealth);

        if (CurrentHealth <= 0)
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

            CurrentHealth = CurrentHealth - 30;
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
}
