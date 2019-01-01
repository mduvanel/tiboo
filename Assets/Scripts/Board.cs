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
                moveDetails.Status = MoveDetails.MoveStatus.BORDER;
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
    }
}
