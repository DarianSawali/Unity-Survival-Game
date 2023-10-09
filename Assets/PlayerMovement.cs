using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 movementInput;
    Rigidbody2D rb;
    public float moveSpeed = 1f;
    public ContactFilter2D movementFilter;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    public float collisionOffset = 0.05f;

    Animator animator;
    SpriteRenderer spriterenderer;
    public Enemy enemy;
    private float damageDelay = 3000f;

    public Health healthBar;

    bool canMove = true;

    public SwordAttack swordAttack;

    [SerializeField] private float attackDamage = 1f;
    [SerializeField] private float damageTimer;

    private bool readyAttack = false;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriterenderer = GetComponent<SpriteRenderer>();
        damageTimer = damageDelay;
    }

    private void FixedUpdate()
    {
        if (canMove) { 
            if (movementInput != Vector2.zero)
            {
                bool success = TryMove(movementInput);

                if (!success)
                {
                    success = TryMove(new Vector2(movementInput.x, 0));

                    if (!success)
                    {
                        success = TryMove(new Vector2(0, movementInput.y));
                    }
                }

                animator.SetBool("isMoving", success);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }

            if (movementInput.x < 0)
            {
                spriterenderer.flipX = true;
                //swordAttack.attackDirection = SwordAttack.AttackDirection.left;
            }
            else if (movementInput.x > 0)
            {
                spriterenderer.flipX = false;
                //swordAttack.attackDirection = SwordAttack.AttackDirection.right;
            }
        }
    }

    private bool TryMove(Vector2 direction)
    {
        int count = rb.Cast(
                movementInput,
                movementFilter,
                castCollisions,
                moveSpeed * Time.fixedDeltaTime + collisionOffset);

        if (count == 0)
        {
            rb.MovePosition(rb.position + movementInput * moveSpeed * Time.fixedDeltaTime);
            return true;
        }
        else
        {
            return false;
        }
    }

  
    private void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }

    void OnFire()
    {
        animator.SetTrigger("swordAttack");
        
    }

    public void Death()
    {
        animator.SetTrigger("Death");
    }

    public void SwingAttack()
    {
        lockMovement();
        if(spriterenderer.flipX == true)
        {
            swordAttack.attackLeft();
        }
        else
        {
            swordAttack.attackRight();
        }

    }

    void lockMovement()
    {
        canMove = false;
        //swordAttack.Attack();
    }

    void unlockMovement()
    {
        swordAttack.StopAttack();
        canMove = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "HealthUp")
        {
            print("HEALTH");
            Powerup healthUp = GetComponent<Powerup>();
            Destroy(healthUp);
        }

        if (other.tag == "Enemy")
        {
            print("sakit");
            enemy.speed = 0;
            Health hp = GetComponent<Health>();
            if (readyAttack = true){
                healthBar.reduceHealth();
                damageTimer = damageDelay;
                readyAttack = false;
            }
        }
    }

    private void Update() {
        if (damageTimer > 0f){
            damageTimer--;
            print("decreasing");
        }
        else if (damageTimer <= 0f){
            print("ready");
            readyAttack = true;
        }
    }


}
