using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tiboo
{
    public class Board
    {
        private readonly Tile[,] m_tiles;

        public int Height { get; set; }
        public int Width { get; set; }

        public Board()
        {
            Width = 4;
            Height = 4;
            m_tiles = new Tile[Width, Height];

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    m_tiles[x, y] = new Tile(Tile.GetAnimal(x, y, Height), Tile.GetColor(x, y));
                }
            }
        }

        // Automatically sets the Wall on both Tiles
        public void SetWall(Wall wall, int x, int y, Tile.Direction direction)
        {
            m_tiles[x, y].SetWall(direction, wall);
            switch(direction)
            {
                case Tile.Direction.EAST:
                    m_tiles[x + 1, y].SetWall(Tile.Direction.WEST, wall);
                    break;
                case Tile.Direction.WEST:
                    m_tiles[x - 1, y].SetWall(Tile.Direction.EAST, wall);
                    break;
                case Tile.Direction.SOUTH:
                    m_tiles[x, y + 1].SetWall(Tile.Direction.NORTH, wall);
                    break;
                case Tile.Direction.NORTH:
                    m_tiles[x, y - 1].SetWall(Tile.Direction.SOUTH, wall);
                    break;
            }
        }

        public Tile GetTile(int x, int y)
        {
            return m_tiles[x, y];
        }
    }
}
