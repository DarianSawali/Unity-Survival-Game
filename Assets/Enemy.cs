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
