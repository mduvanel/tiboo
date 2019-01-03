using System;
using System.Linq;
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

        public static Board GenerateDummyBoard()
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

        public static Board GenerateValidBoard(int magicDoors)
        {
            Board board;
            do
            {
                board = GenerateBoard(magicDoors);
            } while (!board.IsFullyConnected());

            return board;
        }

        static Random RNG;
        static Random GetRandom {
            get { return RNG ?? (RNG = new Random(unchecked(Environment.TickCount * 31))); }
        }

        static List<Wall.Type> ShuffleList(List<Wall.Type> list)
        {
            return list.OrderBy(a => GetRandom.Next()).ToList();
        }

        static Board GenerateBoard(int magicDoors)
        {
            if (magicDoors < 1 || magicDoors > WALLTYPE_COUNTS[Wall.Type.MAGIC_DOOR])
            {
                throw new System.Exception("Invalid number of magic doors requested: " + magicDoors);
            }

            Board board = new Board();

            // Create a list with all non magic doors walls
            List<Wall.Type> allWalls = new List<Wall.Type>();
            foreach (KeyValuePair<Wall.Type, int> entry in WALLTYPE_COUNTS)
            {
                if (entry.Key != Wall.Type.MAGIC_DOOR)
                {
                    for (int i = 0; i < entry.Value; ++i)
                    {
                        allWalls.Add(entry.Key);
                    }
                }
            }

            // Shuffle and trim to get rid of extra walls
            List<Wall.Type> shuffledWalls = ShuffleList(allWalls);
            int wallsToKeep = 24 - magicDoors;
            shuffledWalls.RemoveRange(wallsToKeep, shuffledWalls.Count - wallsToKeep);

            // Add magic doors and shuffle again
            for (int i = 0; i < magicDoors; ++i)
            {
                shuffledWalls.Add(Wall.Type.MAGIC_DOOR);
            }
            List<Wall.Type> finalWalls = ShuffleList(shuffledWalls);

            // Fill the board
            int index = 0;
            for (int x = 0; x < board.Width; ++x)
            {
                for (int y = 0; y < board.Height; ++y)
                {
                    if (x < board.Width - 1)
                    {
                        board.SetWall(new Wall(finalWalls[index++]), x, y, Tile.Direction.EAST);
                    }
                    if (y < board.Height - 1)
                    {
                        board.SetWall(new Wall(finalWalls[index++]), x, y, Tile.Direction.SOUTH);
                    }
                }
            }

            return board;
        }
	}
}