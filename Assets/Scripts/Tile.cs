using System.Collections.Generic;
using System;

namespace Tiboo
{
    static class DirectionExtensions
    {
        static readonly Dictionary<Tile.Direction, Tile.Direction> OPPOSITES =
            new Dictionary<Tile.Direction, Tile.Direction>
            {
                { Tile.Direction.EAST, Tile.Direction.WEST },
                { Tile.Direction.WEST, Tile.Direction.EAST },
                { Tile.Direction.NORTH, Tile.Direction.SOUTH },
                { Tile.Direction.SOUTH, Tile.Direction.NORTH }
            };

        public static Tile.Direction Opposite(this Tile.Direction direction)
        {
            return OPPOSITES[direction];
        }
    }

    public class Tile
    {
        public enum Direction
        {
            NONE,
            NORTH,
            EAST,
            SOUTH,
            WEST
        }

        public enum Animal
		{
			OWL,
			FROG,
			BAT,
            CENTIPEDE
        }

		public enum Color
		{
			WHITE,
			BLACK
		}

		// The Walls surrounding this Tile, a null value means a border Tile
		readonly Dictionary<Direction, Wall> m_walls;

		readonly Animal m_animal;

		readonly Color m_color;

		public Tile(Animal animal, Color color)
		{
            m_walls = new Dictionary<Direction, Wall>()
            {
                { Direction.NORTH, null },
                { Direction.EAST,  null },
                { Direction.SOUTH, null },
                { Direction.WEST,  null }
            };
            m_animal = animal;
			m_color = color;
		}

        public void SetWall(Direction direction, Wall wall)
        {
            m_walls[direction] = wall;
        }

        public Wall GetWall(Direction direction)
        {
            return m_walls[direction];
        }

		public static Color GetColor(int x, int y)
		{
			return (Color)((x + y) % 2);
		}

		public static Animal GetAnimal(int x, int y, int width)
		{
			switch (x + width * y)
			{
			case 2:
			case 4:
			case 11:
			case 13:
                return Animal.FROG;
			case 5:
			case 6:
			case 9:
			case 10:
				return Animal.BAT;
			case 0:
			case 3:
			case 12:
			case 15:
				return Animal.OWL;
			case 1:
			case 7:
			case 8:
			case 14:
                return Animal.CENTIPEDE;
			default:
				throw new Exception("Invalid Tile index. X = " + x + ", Y = " + y);
			}
		}
	}
}