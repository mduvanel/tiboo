namespace Tiboo
{
    public class MoveDetails
    {
        public enum MoveStatus
        {
            SUCCESS_KNOWN,
            SUCCESS_NEW,
            FAILURE,
            ABORTED  // When attempting to move through the outer walls
        }

        public MoveStatus Status { get; set; }
        public Wall.Type WallType { get; set; }
        public Player Player { get; set; }
        public bool PlayAgain { get; set; }

        public MoveDetails(Player player)
        {
            Player = player;
            PlayAgain = false;
        }
    }
}
