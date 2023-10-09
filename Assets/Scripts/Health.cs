using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    Animator animator;
    public GameObject Player;

    PlayerMovement player;

    public GameObject Heart1;
    public GameObject Heart2;
    public GameObject Heart3;
    public GameObject Heart4;
    public GameObject Heart5;
    public GameObject Heart6;

    public int health;
    public int maxHealth = 5;
    // Start is called before the first frame update
    void Start()
    {
        int health = maxHealth;
        Animator animator = GetComponent<Animator>();
        //animator.SetBool("isAlive", true);
    }

    // Update is called once per frame
    void Update()
    {
        // testing, remove before final
        if(Input.GetKeyDown(KeyCode.Q))
        {
            health--;
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            health++;
        }

        // not sure if this will stay, probably will
        if(health <= 0) {
            print("Dead");
            SceneManager.LoadScene("LoseScreen");
            //player.Death();
        }

        switch(health) {
            case 0: {
                Heart1.gameObject.SetActive(false);
                Heart2.gameObject.SetActive(false);
                Heart3.gameObject.SetActive(false);
                Heart4.gameObject.SetActive(false);
                Heart5.gameObject.SetActive(false);
                Heart6.gameObject.SetActive(false);
                break;
            }
            case 1: {
                Heart1.gameObject.SetActive(true);
                Heart2.gameObject.SetActive(false);
                Heart3.gameObject.SetActive(false);
                Heart4.gameObject.SetActive(false);
                Heart5.gameObject.SetActive(false);
                Heart6.gameObject.SetActive(false);
                break;
            }
            case 2: {
                Heart1.gameObject.SetActive(true);
                Heart2.gameObject.SetActive(true);
                Heart3.gameObject.SetActive(false);
                Heart4.gameObject.SetActive(false);
                Heart5.gameObject.SetActive(false);
                Heart6.gameObject.SetActive(false);
                break;
            }
            case 3: {
                Heart1.gameObject.SetActive(true);
                Heart2.gameObject.SetActive(true);
                Heart3.gameObject.SetActive(true);
                Heart4.gameObject.SetActive(false);
                Heart5.gameObject.SetActive(false);
                Heart6.gameObject.SetActive(false);
                break;
            }
            case 4: {
                Heart1.gameObject.SetActive(true);
                Heart2.gameObject.SetActive(true);
                Heart3.gameObject.SetActive(true);
                Heart4.gameObject.SetActive(true);
                Heart5.gameObject.SetActive(false);
                Heart6.gameObject.SetActive(false);
                break;
            }
            case 5: {
                Heart1.gameObject.SetActive(true);
                Heart2.gameObject.SetActive(true);
                Heart3.gameObject.SetActive(true);
                Heart4.gameObject.SetActive(true);
                Heart5.gameObject.SetActive(true);
                Heart6.gameObject.SetActive(false);
                break;
            }
            case 6: {
                Heart1.gameObject.SetActive(true);
                Heart2.gameObject.SetActive(true);
                Heart3.gameObject.SetActive(true);
                Heart4.gameObject.SetActive(true);
                Heart5.gameObject.SetActive(true);
                Heart6.gameObject.SetActive(true);
                break;
            }
        }
    }

    void TakeDamage(int amount)
    {
        health -= amount;

        if(health <= 0) {
            SceneManager.LoadScene("LoseScreen");
        }
    }

    public void reduceHealth()
    {
        health--;
    }

    public void addHealth()
    {
        if(health == maxHealth) {
            maxHealth++;
            health++;
        } else {
            health++;
        }
    }
}
