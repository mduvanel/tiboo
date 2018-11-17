using System.Collections;
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
        public GameObject m_board;

        public GameObject m_soundManagerObject;
        public GameObject m_gameInputObject;

        // Actual scrip instances
        SoundManager m_soundManager;
        GameInput m_gameInput;

        // The actual game object
        Game m_game;

        // Use this for initialization
        public void Start()
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
            m_soundManagerObject.SetActive(true);
            m_gameInputObject.SetActive(true);
            m_soundManager = m_soundManagerObject.GetComponent<SoundManager>();
            m_gameInput = m_gameInputObject.GetComponent<GameInput>();
        }

        public void Update()
        {
            if (!m_soundManager.Done())
            {
                Debug.Log("Waiting for sound to finish playing...");
                return;
            }

            Tile.Direction input = m_gameInput.GetNewInput();
            if (input != Tile.Direction.NONE)
            {
                Debug.Log("Input detected : " + input);
                m_soundManager.PlayAllSounds(SoundMixer.GetMoveSounds(
                    m_game.Move(input)
                ));
            }
        }
    }
}
