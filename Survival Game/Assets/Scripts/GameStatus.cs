using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class GameStatus : MonoBehaviour {
    void Start() {
        
    }

    void Update() {
        
    }

    void toggleWaterCollider(){
        GameObject collider = GameObject.Find("Starter Island Collider");
        if(collider.GetComponent<TilemapCollider2D>().enabled){

        }
    }
}
