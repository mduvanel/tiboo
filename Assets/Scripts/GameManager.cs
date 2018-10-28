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

        public AudioSource m_audioSource;

        // The AudioClips for each sound
        public Dictionary<SoundMixer.SoundFX, AudioClip> m_clips;

        // The grid used to draw players
        public Grid m_grid;

        // The actual game object
        private Game m_game;

        // Control when user input is taken into account
        private bool m_readyToMove;

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
            m_readyToMove = true;
        }

        private void PlaySounds(List<SoundMixer.SoundFX> sounds)
        {
            foreach (SoundMixer.SoundFX soundFX in sounds)
            {
                m_audioSource.clip = m_clips[soundFX];
                m_audioSource.Play();
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (!m_readyToMove)
            {
                return;
            }

            int horizontal = (int) Input.GetAxisRaw("Horizontal");
            int vertical = (int)Input.GetAxisRaw("Vertical");

            if (horizontal != 0 || vertical != 0)
            {
                m_readyToMove = false;
                MoveDetails moveDetails;
                if (horizontal > 0)
                {
                    moveDetails = m_game.Move(Tile.Direction.EAST);
                }
                else if (horizontal < 0)
                {
                    moveDetails = m_game.Move(Tile.Direction.WEST);
                }
                else if (vertical < 0)
                {
                    moveDetails = m_game.Move(Tile.Direction.SOUTH);
                }
                else
                {
                    moveDetails = m_game.Move(Tile.Direction.NORTH);
                }

                PlaySounds(SoundMixer.GetMoveSounds(moveDetails));
            }
        }
    }
}
