using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGenerator : MonoBehaviour {
    [SerializeField] float rockChance = 5f;
    [SerializeField] float stickChance = 0.3f;
    [SerializeField] Transform rock;
    [SerializeField] Transform stick;
    private TileManager tileManager;
    private GameObject[] grasses;
    private ArrayList allRocks = new ArrayList();
    private ArrayList allSticks = new ArrayList();

    void Start() {
        tileManager = GameObject.FindObjectOfType<TileManager>();
    }

    public void spawnResources(){
        allRocks = tileManager.getAllTilePositions();
        foreach(Vector2 position in allRocks){
            if (Random.Range(0, 100) < stickChance){
                Instantiate(stick, position, Quaternion.identity);
            }
            else if (Random.Range(0, 100) < rockChance){
                Instantiate(rock, position, Quaternion.identity);
            }
        }
    }
}
