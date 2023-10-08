using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 3;
    public int health = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    void TakeDamage(int amount)
    {
        health -= amount;

        if(health <= 0) {
            //dead
        }
    }
}
