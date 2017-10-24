using UnityEngine;
using System.Collections;

public class Meat : Ingredients
{
	public enum Chopped
	{
		full = 0,
		half = 1,
		quarters = 2,
		strips = 3,
		cubes = 4,
		sliced = 5,
		ground = 6
	};

	public Chopped chopLevel;
	public bool frozen;

	public Meat()
	{
		chopLevel = Chopped.full;
		frozen = false;
		Debug.Log("Default Meat Constructor Called");
	}

	public Meat(Type iType, Location iLocation)
	{
		itemType = iType;
		itemLocation = iLocation;
		movable = true;
		choppable = true;
		chopLevel = Chopped.full;
		frozen = false;
		Debug.Log("Meat Constructor Called");
	}
}
