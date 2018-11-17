using UnityEngine;

namespace Tiboo
{
    public class GameInput : MonoBehaviour
    {
        bool m_waitForNoInput;

        Tile.Direction m_newInput;

        void Awake()
        {
            m_waitForNoInput = false;
            m_newInput = Tile.Direction.NONE;
        }

        Tile.Direction GetCurrentInput()
        {
            int horizontal = (int)Input.GetAxisRaw("Horizontal");
            int vertical = (int)Input.GetAxisRaw("Vertical");

            if (horizontal != 0)
            {
                return (horizontal < 0) ? Tile.Direction.WEST : Tile.Direction.EAST;
            }

            if (vertical != 0)
            {
                return (vertical < 0) ? Tile.Direction.SOUTH : Tile.Direction.NORTH;
            }

            return Tile.Direction.NONE;
        }

        public Tile.Direction GetNewInput()
        {
            if (m_waitForNoInput)
            {
                return Tile.Direction.NONE;
            }

            m_waitForNoInput |= m_newInput != Tile.Direction.NONE;
            return m_newInput;
        }

        void Update()
        {
            m_newInput = GetCurrentInput();

            if (m_waitForNoInput && m_newInput == Tile.Direction.NONE)
            {
                m_waitForNoInput = false;
            }
        }
    }
}