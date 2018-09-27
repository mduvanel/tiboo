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

        public enum MoveStatus
        {
            SUCCESS_KNOWN,
            SUCCESS_NEW,
            FAILURE
        }

		static readonly Dictionary<Type, int> WALLTYPE_COUNTS;

        public Type WallType { get; set; }
        private bool m_discovered;

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
            m_discovered = false;
        }

        public virtual MoveStatus GoThrough(Player player, Player destinationTilePlayer)
        {
            MoveStatus successStatus = m_discovered ? MoveStatus.SUCCESS_KNOWN : MoveStatus.SUCCESS_NEW;
            m_discovered = true;

            switch (WallType)
            {
                case Wall.Type.OPEN:
                    return successStatus;
                case Wall.Type.CLOSED:
                    return MoveStatus.FAILURE;
                case Wall.Type.MOUSE_HOLE:
                    return ( player.AnimalType == Player.Animal.MOUSE ) ? successStatus : MoveStatus.FAILURE;
                case Wall.Type.RABBIT_HOLE:
                    return ( player.AnimalType == Player.Animal.RABBIT ) ? successStatus : MoveStatus.FAILURE;
                case Wall.Type.MAGIC_DOOR:
                    return ( destinationTilePlayer != null ) ? successStatus: MoveStatus.FAILURE;
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

        public override MoveStatus GoThrough(Player player, Player destinationTilePlayer)
        {
            if (Opened)
            {
                return MoveStatus.SUCCESS_KNOWN;
            }

            MoveStatus status = base.GoThrough(player, destinationTilePlayer);
            if (status != MoveStatus.FAILURE)
            {
                Opened = true;
            }

            return status;
        }
    }
}