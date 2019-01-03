using System.Collections.Generic;

namespace Tiboo
{
    public class Board
    {
        static readonly HashSet<Wall.Type> RABBIT_WALL_TYPES;
        static readonly HashSet<Wall.Type> MOUSE_WALL_TYPES;

        static Board()
        {
            RABBIT_WALL_TYPES = new HashSet<Wall.Type>()
            {
                Wall.Type.OPEN,
                Wall.Type.RABBIT_HOLE
            };

            MOUSE_WALL_TYPES = new HashSet<Wall.Type>()
            {
                Wall.Type.OPEN,
                Wall.Type.MOUSE_HOLE
            };
        }

        readonly Tile[,] m_tiles;

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
            GetTile(x, y, direction).SetWall(direction.Opposite(), wall);
        }

        public Tile GetTile(Player player)
        {
            return m_tiles[player.Pos.x, player.Pos.y];
        }

        public Tile GetTile(int x, int y)
        {
            return m_tiles[x, y];
        }

        public Tile GetTile(int x, int y, Tile.Direction direction)
        {
            switch (direction)
            {
                case Tile.Direction.EAST:
                    return m_tiles[x + 1, y];
                case Tile.Direction.WEST:
                    return m_tiles[x - 1, y];
                case Tile.Direction.SOUTH:
                    return m_tiles[x, y + 1];
                case Tile.Direction.NORTH:
                    return m_tiles[x, y - 1];
            }
            return null;
        }

        public void Move(
            Tile.Direction direction,
            Player movingPlayer,
            Player destinationTilePlayer,
            MoveDetails moveDetails
        ) {
            Tile currentTile = GetTile(movingPlayer);
            Wall wall = currentTile.GetWall(direction);
            if (wall == null)
            {
                moveDetails.Status = MoveDetails.MoveStatus.ABORTED;
            }
            else
            {
                wall.GoThrough(
                    movingPlayer, destinationTilePlayer, moveDetails
                );
                if (moveDetails.Status != MoveDetails.MoveStatus.FAILURE)
                {
                    movingPlayer.Pos.Move(direction);
                }
            }
        }

        public bool IsFullyConnected()
        {
            return IsFullyConnectedWithWallTypes(MOUSE_WALL_TYPES) &&
                IsFullyConnectedWithWallTypes(RABBIT_WALL_TYPES);
        }

        bool IsFullyConnectedWithWallTypes(
            HashSet<Wall.Type> validWallTypes
        ) {
            int tilesCount = Width * Height;

            Queue<Position> positionsToProcess = new Queue<Position>();
            positionsToProcess.Enqueue(new Position(0, 0));
            HashSet<Position> processedPositions = new HashSet<Position>();
            List<Tile.Direction> possibleDirections = new List<Tile.Direction>
            {
                Tile.Direction.EAST,
                Tile.Direction.WEST,
                Tile.Direction.NORTH,
                Tile.Direction.SOUTH
            };

            while ((positionsToProcess.Count > 0) &&
                   (positionsToProcess.Count + processedPositions.Count < tilesCount))
            {
                Position currentPosition = positionsToProcess.Dequeue();
                Tile currentTile = GetTile(currentPosition.x, currentPosition.y);

                // Check for all directions that apply if the tile can be reached
                foreach (Tile.Direction direction in possibleDirections)
                {
                    Wall wall = currentTile.GetWall(direction);
                    if (wall != null && validWallTypes.Contains(wall.WallType))
                    {
                        Position newPosition = currentPosition.OffsetPosition(direction);

                        // If the new position is neither in the processed set
                        // or in the "to process" queue, enqueue it
                        if (!processedPositions.Contains(newPosition) &&
                            !positionsToProcess.Contains(newPosition))
                        {
                            positionsToProcess.Enqueue(newPosition);
                        }
                    }
                }

                // Rinse and repeat
                processedPositions.Add(currentPosition);
            }

            return positionsToProcess.Count + processedPositions.Count == tilesCount;
        }
    }
}
