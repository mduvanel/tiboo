using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tiboo;

public class TilesCreate : MonoBehaviour
{    
    // Following public variable is used to store the tile model prefab;
    // Instantiate it by dragging the prefab on this variable using unity editor
    public GameObject m_tile;
    public Grid m_grid;

    private Board m_board;

	// Use this for initialization
	void Start()
    {
        Vector3 p1 = m_tile.transform.TransformPoint(0, 0, 0);
        Vector3 p2 = m_tile.transform.TransformPoint(1, 1, 0);
        float tileWidth = p2.x - p1.x;
        float tileHeight = p2.y - p1.y;
        
        // GameObject which is the parent of all the tiles
        GameObject tileGrid = new GameObject("Grid");

        for (int x = 0; x < m_board.Width; x++)
        {
            for (int y = 0; y < m_board.Height; y++)
            {
                // GameObject assigned to public variable is cloned
                GameObject tile = (GameObject)Instantiate(m_tile);

                // Current position in grid
                tile.transform.position = new Vector3(x * tileWidth, y * tileHeight, 0);
                tile.transform.parent = tileGrid.transform;
            }
        }
	}
}
