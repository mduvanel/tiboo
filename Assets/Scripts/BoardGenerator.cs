using System.Collections;
using System.Collections.Generic;

namespace Tiboo
{
	public static class BoardGenerator
    {
        static readonly Dictionary<Wall.Type, int> WALLTYPE_COUNTS;

        static BoardGenerator()
        {
            WALLTYPE_COUNTS = new Dictionary<Wall.Type, int>()
            {
                { Wall.Type.OPEN, 14 },
                { Wall.Type.RABBIT_HOLE, 4 },
                { Wall.Type.MOUSE_HOLE, 4 },
                { Wall.Type.MAGIC_DOOR, 3 },
                { Wall.Type.CLOSED, 2 }
            };
        }

        public static Board GenerateBoard()
        {
            Board board = new Board();

            // Dummy implementation with all open walls
            for (int x = 0; x < board.Width; ++x)
            {
                for (int y = 0; y < board.Height; ++y)
                {
                    if (x < board.Width - 1)
                    {
                        board.SetWall(new Wall(Wall.Type.OPEN), x, y, Tile.Direction.EAST);
                    }
                    if (y < board.Height - 1)
                    {
                        board.SetWall(new Wall(Wall.Type.OPEN), x, y, Tile.Direction.SOUTH);
                    }
                }
            }

			return board;
		}
	}
}