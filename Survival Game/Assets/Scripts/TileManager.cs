using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class TileManager : MonoBehaviour {

    [SerializeField] Tilemap map;
    [SerializeField] List<TileData> tileDatas;
    private Dictionary<TileBase, TileData> dataFromTiles;

    void Awake(){
        dataFromTiles = new Dictionary<TileBase, TileData>();
        foreach(var tileData in tileDatas){
            foreach(var tile in tileData.tiles){
                dataFromTiles.Add(tile, tileData);
            }
        }
    }

    void Update() {
        
    }
}
