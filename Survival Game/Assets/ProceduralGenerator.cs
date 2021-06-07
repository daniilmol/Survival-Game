using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGenerator : MonoBehaviour {
    [SerializeField] float rockChance = 5f;
    [SerializeField] float stickChance = 0.3f;
    [SerializeField] Transform rock;

    private GameObject[] grasses;

    void Start() {
        grasses = GameObject.FindGameObjectsWithTag("Grass");
        for(int i = 0; i < grasses.Length; i++){
            if(Random.Range(0, 100) <= rockChance){
                Instantiate(rock, grasses[i].transform.position, Quaternion.identity);
            }
        }
    }
}
