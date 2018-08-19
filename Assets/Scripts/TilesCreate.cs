using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesCreate : MonoBehaviour
{    
    // Following public variable is used to store the tile model prefab;
    // Instantiate it by dragging the prefab on this variable using unity editor
    public GameObject m_tile;
    public Grid m_grid;

    private const int m_height = 4;
    private const int m_width = 4;

    private Tile[,] m_tiles;

    Tile.Color GetColor(int x, int y)
    {
        return (Tile.Color)((x + y) % 2);
    }

    Tile.Animal GetAnimal(int x, int y)
    {
        switch (x + m_width * y)
        {
        case 2:
        case 4:
        case 11:
        case 13:
            return Tile.Animal.FROG;
        case 5:
        case 6:
        case 9:
        case 10:
            return Tile.Animal.BAT;
        case 0:
        case 3:
        case 12:
        case 15:
            return Tile.Animal.OWL;
        case 1:
        case 7:
        case 8:
        case 14:
            return Tile.Animal.WORM;
        default:
            throw new Exception("Invalid Tile index. X = " + x + ", Y = " + y);
        }
    }


	// Use this for initialization
	void Start()
    {
        Vector3 p1 = m_tile.transform.TransformPoint(0, 0, 0);
        Vector3 p2 = m_tile.transform.TransformPoint(1, 1, 0);
        float tileWidth = p2.x - p1.x;
        float tileHeight = p2.y - p1.y;
        
        // GameObject which is the parent of all the tiles
        GameObject tileGrid = new GameObject("Grid");
        m_tiles = new Tile[m_width, m_height];

        for (int x = 0; x < m_width; x++)
        {
            for (int y = 0; y < m_height; y++)
            {
                m_tiles[x, y] = new Tile(GetAnimal(x, y), GetColor(x, y));
                // GameObject assigned to public variable is cloned
                GameObject tile = (GameObject)Instantiate(m_tile);

                // Current position in grid
                tile.transform.position = new Vector3(x * tileWidth, y * tileHeight, 0);
                tile.transform.parent = tileGrid.transform;
            }
        }
	}
}
