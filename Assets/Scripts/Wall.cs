using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall
{
	enum WallType
	{
		OPEN,
		RABBIT_HOLE,
		MOUSE_HOLE,
		MAGIC_DOOR,
		CLOSED
	}

	private static Dictionary<WallType, int> WALLTYPE_COUNTS;

	static Wall()
	{
		WALLTYPE_COUNTS = new Dictionary<WallType, int>()
		{
			{WallType.OPEN, 14},
			{WallType.RABBIT_HOLE, 4},
			{WallType.MOUSE_HOLE, 4},
			{WallType.MAGIC_DOOR, 3},
			{WallType.CLOSED, 2}
		};
	}

	// Generate a random game board of 4 by 4 with the given number of magic doors
	static void GenerateWalls(int magicDoors)
	{

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
