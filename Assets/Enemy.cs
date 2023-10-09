using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator animator;
    public GameObject player;
    SpriteRenderer spriterenderer;
    public Health healthBar;

    public float speed;
    private float distance;
    public float health = 3;

    [SerializeField] private float attackDamage = 1f;
    [SerializeField] private float damageTimer = 0;
    private float damageDelay = 1f;


    public float Health
    {
        set
        {
            health = value;
            if(health <= 0)
            {
                Defeated();
            }
        }
        get
        {
            return health;
        }
    }

    public void Start()
    {
        animator = GetComponent<Animator>();
        spriterenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector2 scale = transform.localScale;

        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);

    }

    void OnCollisionEnter(Collision collision) 
    { 
        // Check if the collider that has collided with the enemy is the player 
        if (collision.collider.tag == "Player") 
        {
            PlayerMovement me = GetComponent<PlayerMovement>();
            // Check if the player is currently able to take damage (i.e. the damage timer is less than or equal to zero) 
            // if (damageTimer <= 0) 
            // { 
            //     // Subtract the damage amount from the player's health 
            //     PlayerHealth playerHealth = collision.collider.GetComponent<PlayerHealth>(); 
            //     playerHealth.TakeDamage(attackDamage); 
 
            //     // Reset the damage timer 
            //     damageTimer = damageDelay; 
            print("attacked");
            // } 
        } 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //print("ouch");
            //speed = 0;
            //healthBar.reduceHealth();
        }
    }

    public void Defeated()
    {
        animator.SetTrigger("Defeated");
        speed = 0;
    }

    public void Hit()
    {
        //animator.SetBool("Hit", true);
        animator.SetTrigger("Hit");
    }

    public void RemoveEnemy()
    {
        Destroy(gameObject);
    }
}
