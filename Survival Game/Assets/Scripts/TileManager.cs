using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class TileManager : MonoBehaviour {

    [SerializeField] Tilemap map;
    [SerializeField] List<TileData> tileDatas;
    private Dictionary<TileBase, TileData> dataFromTiles;
    private bool finished;
    [SerializeField] ProceduralGenerator generator;
    void Awake(){
        finished = false;
        dataFromTiles = new Dictionary<TileBase, TileData>();
        foreach(var tileData in tileDatas){
            foreach(var tile in tileData.tiles){
                if(tile != null && tileData != null){
                    //Debug.Log(tile + " " + tileData);
                    dataFromTiles.Add(tile, tileData);
                }
            }
        }
        finished = true;
    }

    void Update() {
        if(finished){
            generator.spawnRocks();
            finished = false;
        }
    }
    public ArrayList getAllTilePositions(){
        BoundsInt bounds = map.cellBounds;
        TileBase[] allTiles = map.GetTilesBlock(bounds);
        ArrayList validPositions = new ArrayList();
        ArrayList allPositions = new ArrayList();
        for(int i = -100; i < 100; i++){
            for(int j = -100; j < 100; j++){
                allPositions.Add(new Vector2(i, j));
            }
        }
        foreach(Vector2 pos in allPositions){
            //Debug.Log(pos);
            Vector3Int gridPos = map.WorldToCell(new Vector2(pos.x, pos.y));
            TileBase tile = map.GetTile(gridPos);
            if(tile != null){
                try{
                    float stepCode = dataFromTiles[tile].footstepCode;
                    Debug.Log(stepCode);
                    if(stepCode == 0){
                        Debug.Log("added");
                        validPositions.Add(pos);
                    }
                }catch(KeyNotFoundException e){

                }
            }else{
                Debug.Log("null");
            }
        }
        return validPositions;
    }
    public bool waterAhead(float xDir, float yDir){
        Vector3Int gridPos = map.WorldToCell(new Vector2(xDir, yDir));
        TileBase tile = map.GetTile(gridPos);
        if(tile != null){
            try{
                float stepCode = dataFromTiles[tile].footstepCode;
                if(stepCode == 3){
                    return true;
                }
            }catch(KeyNotFoundException e){
            }
        }else{
            Debug.Log("null");
        }
        return false;
    }
}
