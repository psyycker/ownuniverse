using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGenerator : MonoBehaviour
{
    private GameObject _gridGameObject;
    private Grid _grid;
    private TerrainTiles _terrain;
    [SerializeField]
    private GameObject groundTileMapPrefab;

    private GameObject _groundTileMap;

    private void InitGrid()
    {
        _gridGameObject = new GameObject();
        _gridGameObject.name = "world";
        _gridGameObject.transform.position = new Vector3(0, 0, 0);
        _gridGameObject.AddComponent<Grid>();
        _grid = _gridGameObject.GetComponent<Grid>();
    }

    private void InitTileMap()
    {
        _groundTileMap = Instantiate(groundTileMapPrefab, _gridGameObject.transform, true);
        _groundTileMap.name = "ground";
    }
    
    // private GameObject _groundTileMap;
    // Start is called before the first frame update
    void Start()
    {
        _terrain = GetComponent<TerrainTiles>();
        InitGrid();
        InitTileMap();
        GenMap();
    }

    void GenMap()
    {
        Debug.Log("GEN");
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
