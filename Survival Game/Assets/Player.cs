using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] float health;
    [SerializeField] float maxHealth = 100;
    [SerializeField] HealthBar healthBar;
    void Start() {
        health = maxHealth;
        healthBar.setSliderValue(maxHealth);
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Space)){
            damage(20);
        }
    }

    public void damage(int damage){
        health -= damage;
        healthBar.setSliderValue(health);
    }
}
