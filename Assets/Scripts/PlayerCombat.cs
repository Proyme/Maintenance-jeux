using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    public float attackRange = 0.6f;
    public int attackDamage = 20;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }
    }

    void Attack()
    {
        // faire l'animation attaquer
        animator.SetTrigger("Attack");

        //détecter les énemis
        Collider2D[] hitEnemies =  Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //dommage aux énemis
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyBehaviour>().TakeHit(attackDamage);
            enemy.GetComponent<EnemyFollow>().TakeHit(attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        var enemyBat = collision.collider.GetComponent<EnemyFollow>();
        var enemySke = collision.collider.GetComponent<EnemyFollow>();

        if (enemyBat || enemySke)
        {
            enemyBat.TakeHit(1);
            enemySke.TakeHit(1);
        }
    }*/
}
