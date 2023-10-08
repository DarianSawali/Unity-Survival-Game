using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public PoweupEffect powerupEffect;
    public GameObject player;
    public Health healthBar;

    private void Start()
    {
        //Health health = GetComponent<Health>();
    }

    public void Apply(GameObject player)
    {
        //health.health--;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //check here for player

        if(other.tag == "Player"){
            PlayerMovement player = GetComponent<PlayerMovement>();
            Health health = GetComponent<Health>();
            print("hit");
            healthBar.addHealth();
            Destroy(gameObject);
        }

        //if(collision.gameObject.CompareTag("Player")) {
        //  Destroy(gameObject);
        //  powerupEffect.Apply(collision.gameObject);
        //}
        else {
            
        }
    }
}
