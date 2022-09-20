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
            Vector2 playerPos = _player.position;
            float dist = Vector2.Distance(clickPos, playerPos);
            if (dist < 4)
            {
                _tilemap.SetTile(_tilemap.WorldToCell(clickPos), null);
            }
        }
    }
}
