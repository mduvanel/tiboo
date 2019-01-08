using System.Collections.Generic;

namespace Tiboo
{
    static class TypeExtensions
    {
        public static char ToChar(this Wall.Type type)
        {
            switch(type)
            {
                case Wall.Type.OPEN:
                    return 'O';
                case Wall.Type.CLOSED:
                    return 'C';
                case Wall.Type.MOUSE_HOLE:
                    return 'M';
                case Wall.Type.RABBIT_HOLE:
                    return 'R';
                case Wall.Type.MAGIC_DOOR:
                    return 'D';
                default:
                    return 'X';
            }
        }
    }

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
        bool m_traversed;

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
	}
}