using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Tiboo
{
	public class Tile
	{
		enum Direction
		{
			NORTH,
			EAST,
			SOUTH,
			WEST
		}

		public enum Animal
		{
			OWL,
			WORM,
			BAT,
			FROG
		}

		public enum Color
		{
			WHITE,
			BLACK
		}

		// The Walls surrounding this Tile, a null value means a border Tile
		private Dictionary<Direction, Wall> m_walls;

		private Animal m_animal;

		private Color m_color;
		
		public Tile(
			Wall NorthWall,
			Wall EastWall,
			Wall SouthWall,
			Wall WestWall,
			Animal animal,
			Color color
		) {
			m_walls = new Dictionary<Direction, Wall>()
			{
				{Direction.NORTH, NorthWall},
				{Direction.EAST,  EastWall},
				{Direction.SOUTH, SouthWall},
				{Direction.WEST,  WestWall}
			};
			m_animal = animal;
			m_color = color;
		}

		public Tile(Animal animal, Color color)
		{
			m_animal = animal;
			m_color = color;
		}

		public static Color GetColor(int x, int y)
		{
			return (Color)((x + y) % 2);
		}

		public static Animal GetAnimal(int x, int y, int width)
		{
			switch (x + width * y)
			{
			case 2:
			case 4:
			case 11:
			case 13:
				return Animal.FROG;
			case 5:
			case 6:
			case 9:
			case 10:
				return Animal.BAT;
			case 0:
			case 3:
			case 12:
			case 15:
				return Animal.OWL;
			case 1:
			case 7:
			case 8:
			case 14:
				return Animal.WORM;
			default:
				throw new Exception("Invalid Tile index. X = " + x + ", Y = " + y);
			}
		}

		// Use this for initialization
		void Start ()
		{
			
		}
		
		// Update is called once per frame
		void Update ()
		{
			
		}
	}
}