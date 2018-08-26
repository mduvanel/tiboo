using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tiboo
{
    public class Player
    {
        public enum Color
        {
            RED,
            GREEN,
            BLUE,
            YELLOW
        }

        public enum Animal
        {
            MOUSE,
            RABBIT
        }

        private Animal m_animal;
        private Color m_color;

        public Player(Animal animal, Color color)
        {
            m_color = color;
            m_animal = animal;
        }
    }
}
