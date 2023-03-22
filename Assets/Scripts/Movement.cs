using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float vitesseMax = 6;
    [SerializeField] float m_jumpForce = 7.5f;

    public bool DefautVersGauche;

    public bool VersDroite = true;
    public Animator m_animateur;
    public Rigidbody2D rb;
    private SpriteRenderer sr;
    private bool m_combatIdle = false;
    private bool m_isDead = false;
    public CapsuleCollider2D playerCollider2D;

    private bool grounded = false, userJump; // Indique si le personnage touche le sol
    public Transform GrondCheck; // Determine si le perso touche le sol ou non
    private float rayonGroud = 0.2f; // Taille du cercle de detection du sol
    public LayerMask GroundLayer; // Associe à un layer tout ce qui doit être considéré comme faisant partie du sol

    private const float JUMP_FORCE = 200f;

    public static Movement instance;

    private void Awake()
    {
        m_animateur = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        if (instance != null)
        {
            Debug.LogWarning("il y a plus d'une d'instance");
            return;
        }
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (!userJump && grounded)// Tant qu'on n'a pas ete "consomme"
            userJump = Input.GetButtonDown("Jump");

        if (Input.GetKeyDown("e"))
        {
            if (!m_isDead)
                m_animateur.SetTrigger("Death");
            else
                m_animateur.SetTrigger("Recover");

            m_isDead = !m_isDead;
        }

        //Hurt
        else if (Input.GetKeyDown("q"))
            m_animateur.SetTrigger("Hurt");

        //Attack
        else if (Input.GetMouseButtonDown(0))
        {
            m_animateur.SetTrigger("Attack");
        }

        //Change between idle and combat idle
        else if (Input.GetKeyDown("f"))
            m_combatIdle = !m_combatIdle;
    }

    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(new Vector2(GrondCheck.position.x, GrondCheck.position.y), rayonGroud, GroundLayer.value);

        float mouvement = Input.GetAxis("Horizontal");

        m_animateur.SetFloat("Speed", Mathf.Abs(mouvement));
        m_animateur.SetBool("Grounded", grounded);

        if (userJump && grounded)
        {
            rb.AddForce(Vector2.up * JUMP_FORCE);
            userJump = false;
        }

        if (mouvement < 0 && VersDroite)
            setDirection(false);

        else if (mouvement > 0 && !VersDroite)
            setDirection(true);

        rb.velocity = new Vector2(mouvement * vitesseMax, rb.velocity.y);
    }

    private void setDirection(bool versDroite)
    {


        VersDroite = versDroite;
        sr.flipX = DefautVersGauche ? versDroite : !versDroite;
    }
}
