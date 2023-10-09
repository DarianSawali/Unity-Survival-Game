using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPowerUp : MonoBehaviour
{
    public PoweupEffect powerupEffect;
    public GameObject player;
    public SwordAttack swordAttack;

    private void Start()
    {
        //Health health = GetComponent<Health>();
    }

    public void Apply(GameObject player)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //check here for player

        if(other.tag == "Player"){
            PlayerMovement player = GetComponent<PlayerMovement>();
            SwordAttack attack = GetComponent<SwordAttack>();
            print("attackbuff");
            swordAttack.addDamage(2);
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
