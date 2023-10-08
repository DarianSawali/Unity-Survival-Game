using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public PoweupEffect powerupEffect;
    public GameObject player;


    private void OnTriggerEnter2D(Collider2D other)
    {
        //check here for player

        if(other.tag == "Player"){
            PlayerMovement player = GetComponent<PlayerMovement>();
            print("hit");
            //powerupEffect.Apply(other.gameObject);
            //Destroy(gameObject);
        }

        //if(collision.gameObject.CompareTag("Player")) {
        //  Destroy(gameObject);
        //  powerupEffect.Apply(collision.gameObject);
        //}
        else {
            
        }
    }
}
