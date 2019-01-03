using System.Collections;
using System.Collections.Generic;

namespace Tiboo
{
    public class Position
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

        public override bool Equals(object obj)
        {
            var pos = obj as Position;

            if (obj == null)
            {
                return false;
            }

            return pos == this;
        }

        public override int GetHashCode()
        {
            return x ^ y;
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
}