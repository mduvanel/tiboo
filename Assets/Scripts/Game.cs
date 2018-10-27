using System;
using System.Collections.Generic;

namespace Tiboo
{
    public class Game
    {
        private List<Player> m_players;
        private Board m_board;

        private int m_currentPlayerIndex;
        private int m_currentTurn;
        private bool m_currentPlayerAlreadyMoved;
        private readonly int m_maxTurns;

        public Game(List<Player> players, Board board, int maxTurns = -1)
        {
            m_currentPlayerIndex = 0;
            m_currentTurn = 0;
            m_currentPlayerAlreadyMoved = false;
            m_maxTurns = maxTurns;
            m_players = players;
            m_board = board;
            
            ValidatePlayers();
        }

        private void ValidatePlayers()
        {
            if ((m_players.Find(x => x.AnimalType == Player.Animal.MOUSE) == null) ||
                (m_players.Find(x => x.AnimalType == Player.Animal.RABBIT) == null))
            {
                throw new Exception("You need at least a rabbit and a mouse to play this game!");
            }
        }

        public MoveDetails Move(Tile.Direction direction)
        {
            Player currentPlayer = m_players[m_currentPlayerIndex];
            MoveDetails moveDetails = new MoveDetails(currentPlayer);
            m_board.Move(
                direction,
                currentPlayer,
                m_players.Find(x => x.Pos == currentPlayer.Pos.OffsetPosition(direction)),
                moveDetails
            );

            if (moveDetails.Status == MoveDetails.MoveStatus.SUCCESS_KNOWN && !m_currentPlayerAlreadyMoved)
            {
                // let the same player play again
                m_currentPlayerAlreadyMoved = true;
            }
            return moveDetails;
        }

        public void NextPlayer()
        {
            m_currentPlayerAlreadyMoved = false;
            ++m_currentPlayerIndex;
            if (m_currentPlayerIndex == m_players.Count)
            {
                ++m_currentTurn;
                m_currentPlayerIndex = 0;
            }
        }
    }
}
