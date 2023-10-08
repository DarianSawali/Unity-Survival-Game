using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator animator;
    public GameObject player;
    SpriteRenderer spriterenderer;

    public float speed;
    private float distance;
    public float health = 3;

    public Health healthBar;
    [SerializeField] private float attackDamage = 1f;
    [SerializeField] private float attackSpeed = 1f;
    private float canAttack;

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

    private void OnCollisionStay2D(Collision2D other) {
        if(other.gameObject.tag == "Player") {
            if (attackSpeed <= canAttack) {
                PlayerMovement player = GetComponent<PlayerMovement>();
                Health health = GetComponent<Health>(); //issue with which health?
                print("attacked");
                healthBar.reduceHealth();
                canAttack = 0f;
            }
            else {
                canAttack += Time.deltaTime;
            }
        }
    }

    //public void TakeDamage(float damage)
    //{
    //   health -= damage;
    //}

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
