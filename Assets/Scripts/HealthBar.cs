using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    Slider _healthslider; 

    private void Start() {
        _healthslider = GetComponent<Slider>();
    }

    public void setMaxHealth(int maxHealth) {
        _healthslider.maxValue = maxHealth;
        _healthslider.value = maxHealth;
    }

    public void setHealth(int health) {
        _healthslider.value = health;
    }
}
