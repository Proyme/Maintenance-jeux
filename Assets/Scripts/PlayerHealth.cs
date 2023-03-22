using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public float invincibleTimeAfterHit = 3f;
    public float InvinsibleFlashDelay = 0.2f;
    public bool invinsible = false;

    public SpriteRenderer graphics;
    public HealthBarPerso healthBar;

    public static PlayerHealth instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Plus d'instance");
            return;
        }
        instance = this;
    }

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

    }

    public void TakeDamage(int damage)
    {
        if (!invinsible)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);

            if (currentHealth <= 0)
            {
                Die();
                return;
            }

            invinsible = true;
            StartCoroutine(InvinsibleFlash());
            StartCoroutine(HandleInvinsibleDelay());
        }
    }

    public void Die()
    {
        Debug.Log("Le joueur est éliminé");
        Movement.instance.enabled = false;
        Movement.instance.m_animateur.SetTrigger("Die");
        Movement.instance.rb.bodyType = RigidbodyType2D.Kinematic;
        Movement.instance.rb.velocity = Vector3.zero;
        Movement.instance.playerCollider2D.enabled = false;
        GameOver.instance.OnPlayerDeath();
    }

    public void Respawn()
    {
        Movement.instance.enabled = true;
        Movement.instance.m_animateur.SetTrigger("Respawn");
        Movement.instance.rb.bodyType = RigidbodyType2D.Kinematic;
        Movement.instance.playerCollider2D.enabled = true;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public IEnumerator InvinsibleFlash()
    {
        while (invinsible)
        {
            graphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(InvinsibleFlashDelay);
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(InvinsibleFlashDelay);
        }
    }

    public IEnumerator HandleInvinsibleDelay()
    {
        yield return new WaitForSeconds(3f);
        invinsible = false;
    }
}
