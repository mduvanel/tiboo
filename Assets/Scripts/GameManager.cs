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
                players.Add(new Player(Player.Animal.RABBIT, Player.Color.GREEN));
            }
            if (m_blueRabbit != null)
            {
                players.Add(new Player(Player.Animal.RABBIT, Player.Color.BLUE));
            }
            if (m_redMouse != null)
            {
                players.Add(new Player(Player.Animal.MOUSE, Player.Color.RED));
            }
            if (m_yellowMouse != null)
            {
                players.Add(new Player(Player.Animal.MOUSE, Player.Color.YELLOW));
            }

            m_game = new Game(players);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
