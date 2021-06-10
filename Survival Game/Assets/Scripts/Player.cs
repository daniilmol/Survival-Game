using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] float health;
    [SerializeField] float maxHealth = 100;
    [SerializeField] float hunger;
    [SerializeField] float maxHunger = 100;
    [SerializeField] float hungerRate = 1f;
    [SerializeField] HealthBar healthBar;
    [SerializeField] HealthBar foodBar;
    [SerializeField] InventoryObject inventory;

    void Start() {
        health = maxHealth;
        hunger = maxHunger;
        healthBar.setSliderValue(maxHealth);
        foodBar.setSliderValue(maxHunger);
        InvokeRepeating("loseHunger", 0, hungerRate);
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Space)){
            damage(20);
        }
    }

    private void loseHunger(){
        hunger--;
        foodBar.setSliderValue(hunger);
    }

    public void damage(int damage){
        health -= damage;
        healthBar.setSliderValue(health);
    }

    public void OnTriggerEnter2D(Collider2D other){
        Debug.Log("Trigger entered");
        var item = other.GetComponent<Item>();
        if(item){
            inventory.addItem(item.item, 1);
            Destroy(other.gameObject);
        }
    }
    private void OnApplicationQuit() {
        inventory.Container.Clear();    
    }
}
