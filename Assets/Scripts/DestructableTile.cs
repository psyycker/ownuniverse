using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DestructableTile : MonoBehaviour
{
    private Tilemap _tilemap;
    private Rigidbody2D _player;

    private void Start()
    {
        _tilemap = GetComponent<Tilemap>();
        _player = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
        HandleClick();
    }

    private void HandleClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // Debug.Log(string.Format("click Y:{0} X:{1}", clickPos.y, clickPos.x));
            Vector2 playerPos = _player.position;
            // Debug.Log(string.Format("player pos Y:{0} X:{1}", playerPos.y, playerPos.x));
            float dist = Vector2.Distance(clickPos, playerPos);
            // Debug.Log(string.Format("distance {0}", dist));
            if (dist < 4)
            {

                Vector3Int pos = _tilemap.WorldToCell(clickPos);
                pos.z = 0;
                _tilemap.SetTile(pos, null);
            }
        }
    }
}
