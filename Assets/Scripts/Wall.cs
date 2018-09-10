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

        public virtual bool GoThrough(Player player, Player destinationTilePlayer)
        {
            switch (WallType)
            {
                case Wall.Type.OPEN:
                    return true;
                case Wall.Type.CLOSED:
                    return false;
                case Wall.Type.MOUSE_HOLE:
                    return player.AnimalType == Player.Animal.MOUSE;
                case Wall.Type.RABBIT_HOLE:
                    return player.AnimalType == Player.Animal.RABBIT;
                case Wall.Type.MAGIC_DOOR:
                    return destinationTilePlayer != null;
            }

            throw new System.Exception("Unknown Wall Type " + WallType);
        }

		// Generate random walls in the given game board with the given number of magic doors
		static void GenerateWalls(Board board, int magicDoors = 1)
		{

		}
	}

    public class MagicDoor : Wall
    {
        private bool Opened { get; set; }

        public MagicDoor() : base(Type.MAGIC_DOOR)
        {
            Opened = false;
        }

        public override bool GoThrough(Player player, Player destinationTilePlayer)
        {
            if (Opened)
            {
                return true;
            }

            if (base.GoThrough(player, destinationTilePlayer))
            {
                Opened = true;
                return true;
            }

            return false;
        }
    }
}