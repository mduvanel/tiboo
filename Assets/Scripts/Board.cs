using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tiboo
{
    public class Board
    {
        private readonly Tile[,] m_tiles;

        public int Height { get; }
        public int Width { get; }

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
    }
}
