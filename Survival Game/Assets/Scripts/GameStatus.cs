using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class GameStatus : MonoBehaviour {
    void Start() {
        
    }

    void Update() {
        
    }

    public void toggleWaterCollider(){
        print("djkjkjk");
        GameObject collider = GameObject.Find("Starter Island Collider");
        if(collider.GetComponent<TilemapCollider2D>().enabled){
            collider.GetComponent<TilemapCollider2D>().enabled = false;
        }else{
            collider.GetComponent<TilemapCollider2D>().enabled = true;
        }
    }
}
