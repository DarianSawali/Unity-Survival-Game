using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public PoweupEffect powerupEffect;
    private void onTriggerEnter2D(Collider2D collision)
    {
        //check here for player

        if(collision.gameObject.CompareTag("Player")) {
            Destroy(gameObject);
            powerupEffect.Apply(collision.gameObject);
        }
        else {
            
        }
    }
}
