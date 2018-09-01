using System;
using System.Collections.Generic;

namespace Tiboo
{
    public class Game
    {
        private List<Player> m_players;
        private Board m_board;

        public Game(List<Player> players)
        {
            m_players = players;
            ValidatePlayers();
        }

        void ValidatePlayers()
        {
            if ((m_players.Find(x => x.AnimalType == Player.Animal.MOUSE) == null) ||
                (m_players.Find(x => x.AnimalType == Player.Animal.RABBIT) == null))
            {
                throw new Exception("You need at least a rabbit and a mouse to play this game!");
            }
        }

    }
}
