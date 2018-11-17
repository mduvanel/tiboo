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

        public Type WallType { get; set; }
        private bool m_traversed;

        public Wall(Type type)
        {
            WallType = type;
            m_traversed = false;
        }

        public virtual void GoThrough(Player player, Player destinationTilePlayer, MoveDetails moveDetails)
        {
            MoveDetails.MoveStatus successStatus = m_traversed ?
                MoveDetails.MoveStatus.SUCCESS_KNOWN :
                MoveDetails.MoveStatus.SUCCESS_NEW;

            moveDetails.WallType = WallType;
            switch (WallType)
            {
                case Wall.Type.OPEN:
                    moveDetails.Status = successStatus;
                    break;
                case Wall.Type.CLOSED:
                    moveDetails.Status = MoveDetails.MoveStatus.FAILURE;
                    break;
                case Wall.Type.MOUSE_HOLE:
                    moveDetails.Status = ( player.AnimalType == Player.Animal.MOUSE ) ?
                        successStatus :
                        MoveDetails.MoveStatus.FAILURE;
                    break;
                case Wall.Type.RABBIT_HOLE:
                    moveDetails.Status = ( player.AnimalType == Player.Animal.RABBIT ) ?
                        successStatus :
                        MoveDetails.MoveStatus.FAILURE;
                    break;
                case Wall.Type.MAGIC_DOOR:
                    moveDetails.Status = m_traversed || ( destinationTilePlayer != null ) ?
                        successStatus :
                        MoveDetails.MoveStatus.FAILURE;
                    break;
            }

            m_traversed = moveDetails.Status != MoveDetails.MoveStatus.FAILURE;
        }

		// Generate random walls in the given game board with the given number of magic doors
		static void GenerateWalls(Board board, int magicDoors = 1)
		{

		}
	}
}