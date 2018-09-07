using System.Collections.Generic;

namespace Tiboo
{
	public class Wall
	{
		public enum Type
		{
			OPEN,
			RABBIT_HOLE,
			MOUSE_HOLE,
			MAGIC_DOOR,
			CLOSED
		}

		private static readonly Dictionary<Type, int> WALLTYPE_COUNTS;

        public Type WallType { get; set; }

		static Wall()
		{
			WALLTYPE_COUNTS = new Dictionary<Type, int>()
			{
				{ Type.OPEN, 14 },
				{ Type.RABBIT_HOLE, 4 },
				{ Type.MOUSE_HOLE, 4 },
				{ Type.MAGIC_DOOR, 3 },
				{ Type.CLOSED, 2 }
			};
		}

        public Wall(Type type)
        {
            WallType = type;
        }

		// Generate random walls in the given game board with the given number of magic doors
		static void GenerateWalls(Board board, int magicDoors = 1)
		{

		}
	}
}