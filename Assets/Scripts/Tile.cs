using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
