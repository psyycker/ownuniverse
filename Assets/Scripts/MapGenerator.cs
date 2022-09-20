using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;

public class MapGenerator : MonoBehaviour
{
    private GameObject _gridGO;
    private Grid _grid;
    private TerrainTiles _terrain;
    [SerializeField]
    private GameObject groundTileMapPrefab;

    private GameObject _groundTileMap;

    // private GameObject _groundTileMap;
    // Start is called before the first frame update
    void Start()
    {
        _gridGO = new GameObject();
        _gridGO.name = "world";
        _gridGO.transform.position = new Vector3(0, 0, 0);
        _gridGO.AddComponent<Grid>();
        _grid = _gridGO.GetComponent<Grid>();

        _groundTileMap = Instantiate(groundTileMapPrefab, _gridGO.transform, true);
        _groundTileMap.name = "ground";
        _groundTileMap.AddComponent<DestructableTile>();
        _terrain = GetComponent<TerrainTiles>();
        // GenMap();
    }

    void GenMap()
    {
        Tilemap tilemap = _groundTileMap.GetComponent<Tilemap>();
        for (int y = 0; y < 20; y++)
        {
            for (int x = 0; x < 20; x++)
            {
                tilemap.SetTile(tilemap.WorldToCell(new Vector3(x, y)), _terrain.grassAndDirt);
            }
        }
    }

}
