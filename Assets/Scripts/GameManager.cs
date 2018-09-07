using System.Collections.Generic;
using UnityEngine;

namespace Tiboo
{
    public class GameManager : MonoBehaviour
    {
        // GameObjects 
        public GameObject m_greenRabbit;
        public GameObject m_blueRabbit;
        public GameObject m_redMouse;
        public GameObject m_yellowMouse;

        // The actual game object
        private Game m_game;

        // Use this for initialization
        void Start()
        {
            List<Player> players = new List<Player>();
            if (m_greenRabbit != null)
            {
                players.Add(new Player(Player.Animal.RABBIT, Player.Color.GREEN, new Player.Position(0, 0)));
            }
            if (m_blueRabbit != null)
            {
                players.Add(new Player(Player.Animal.RABBIT, Player.Color.BLUE, new Player.Position(0, 3)));
            }
            if (m_redMouse != null)
            {
                players.Add(new Player(Player.Animal.MOUSE, Player.Color.RED, new Player.Position(3, 0)));
            }
            if (m_yellowMouse != null)
            {
                players.Add(new Player(Player.Animal.MOUSE, Player.Color.YELLOW, new Player.Position(3, 3)));
            }

            m_game = new Game(players, BoardGenerator.GenerateBoard());
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
