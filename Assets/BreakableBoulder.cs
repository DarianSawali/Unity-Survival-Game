using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableBoulder : MonoBehaviour
{
    public GameObject swordAttack;
    private void OnCollisionEnter2D(Collision2D other) {
        Destroy(gameObject);
    }

    public void destroy() {
        Destroy(gameObject);
    }
}
