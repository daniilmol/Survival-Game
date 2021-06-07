using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerChanger : MonoBehaviour {
    [SerializeField] float layerBuffer = -1.4f;
    [SerializeField] int lowerPriorityLayer = 1;
    [SerializeField] int higherPriorityLayer = 3;

    private GameObject player;
    void Start() {
        player = GameObject.Find("Player");
    }

    void Update() {
        Debug.Log(player.transform.position.y - transform.position.y);
        if(player.transform.position.y - transform.position.y < layerBuffer){
            GetComponent<SpriteRenderer>().sortingOrder = lowerPriorityLayer;
        }else{
            GetComponent<SpriteRenderer>().sortingOrder = higherPriorityLayer;
        }
    }
}
