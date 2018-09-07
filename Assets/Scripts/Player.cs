
namespace Tiboo
{
    public class Player
    {
        public enum Color
        {
            RED,
            GREEN,
            BLUE,
            YELLOW
        }

        public enum Animal
        {
            MOUSE,
            RABBIT
        }

        public struct Position
        {
            public int x;
            public int y;

            public Position(int x_, int y_)
            {
                x = x_;
                y = y_;
            }

            public static bool operator ==(Position a, Position b)
            {
                return (a.x == b.x) && (a.y == b.y);
            }

            public static bool operator !=(Position a, Position b)
            {
                return !(a == b);
            }

            public void Move(Tile.Direction direction)
            {
                switch (direction)
                {
                    case Tile.Direction.EAST:
                        x += 1;
                        break;
                    case Tile.Direction.WEST:
                        x -= 1;
                        break;
                    case Tile.Direction.SOUTH:
                        y += 1;
                        break;
                    case Tile.Direction.NORTH:
                        y -= 1;
                        break;
                }
            }

            public Position OffsetPosition(Tile.Direction direction)
            {
                Position position = new Position(x, y);
                position.Move(direction);
                return position;
            }
        }

        public Animal AnimalType { get; set; }
        public Color ColorType { get; set; }
        public Position Pos { get; set; }

        public Player(Animal animal, Color color, Position position)
        {
            ColorType = color;
            AnimalType = animal;
            Pos = position;
        }

        public bool CanMoveTo(Tile tile, bool destinationOccupied, Wall.Type wallType)
        {
            switch(wallType)
            {
                case Wall.Type.OPEN:
                    return true;
                case Wall.Type.CLOSED:
                    return false;
                case Wall.Type.MOUSE_HOLE:
                    return AnimalType == Animal.MOUSE;
                case Wall.Type.RABBIT_HOLE:
                    return AnimalType == Animal.RABBIT;
                case Wall.Type.MAGIC_DOOR:
                    return destinationOccupied;
            }
            throw new System.Exception("Unknown Wall Type " + wallType);
        }
    }
}
