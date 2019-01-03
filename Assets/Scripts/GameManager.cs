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

        // Actual script instances
        SoundManager m_soundManager;
        GameInput m_gameInput;

        // The actual game object
        Game m_game;

        // The state machine for synchronizing inputs and playing sounds
        GameManagerStateMachine m_stateMachine;

        // Use this for initialization
        public void Start()
        {
            // Create players with respective startup position
            List<Player> players = new List<Player>();
            if (m_greenRabbit != null)
            {
                players.Add(new Player(
                    Player.Animal.RABBIT,
                    Player.Color.GREEN,
                    new Position(0, 0)
                ));
            }
            if (m_blueRabbit != null)
            {
                players.Add(new Player(
                    Player.Animal.RABBIT,
                    Player.Color.BLUE,
                    new Position(0, 3)
                ));
            }
            if (m_redMouse != null)
            {
                players.Add(new Player(
                    Player.Animal.MOUSE,
                    Player.Color.RED,
                    new Position(3, 0)
                ));
            }
            if (m_yellowMouse != null)
            {
                players.Add(new Player(
                    Player.Animal.MOUSE,
                    Player.Color.YELLOW,
                    new Position(3, 3)
                ));
            }

            // Create member objects
            m_game = new Game(players, BoardGenerator.GenerateDummyBoard());
            m_stateMachine = new GameManagerStateMachine();
            m_soundManagerObject.SetActive(true);
            m_gameInputObject.SetActive(true);
            m_soundManager = m_soundManagerObject.GetComponent<SoundManager>();
            m_gameInput = m_gameInputObject.GetComponent<GameInput>();

            // Initialize sound manager with startup sounds
            m_soundManager.PlayAllSounds(
                SoundMixer.GetWelcomeSounds(m_game.CurrentPlayer())
            );
        }

        public void Update()
        {
            switch (m_stateMachine.CurrentState)
            {
                case GameManagerStateMachine.State.WAIT_FOR_INPUT:
                    Tile.Direction input = m_gameInput.GetNewInput();
                    if (input != Tile.Direction.NONE)
                    {
                        Debug.Log("Input detected : " + input);
                        MoveDetails moveDetails = m_game.Move(input);
                        List<SoundMixer.SoundFX> allSounds =
                                           SoundMixer.GetMoveSounds(moveDetails);
                        if (moveDetails.Status != MoveDetails.MoveStatus.ABORTED)
                        {
                            allSounds.AddRange(SoundMixer.GetNextPlayerSounds(
                                moveDetails, m_game
                            ));
                        }
                        m_soundManager.PlayAllSounds(allSounds);
                        m_stateMachine.MoveNext(
                            GameManagerStateMachine.Event.INPUT_RECEIVED
                        );
                    }
                    break;
                case GameManagerStateMachine.State.PLAYING_SOUNDS:
                    if (m_soundManager.Done())
                    {
                        m_stateMachine.MoveNext(
                            GameManagerStateMachine.Event.SOUND_FINISHED
                        );
                    }
                    else
                    {
                        Debug.Log("Waiting for sound to finish playing...");
                    }
                    break;
                default:
                    Debug.LogError("Unknown state: " + m_stateMachine.CurrentState);
                    break;
            }
        }
    }
}
