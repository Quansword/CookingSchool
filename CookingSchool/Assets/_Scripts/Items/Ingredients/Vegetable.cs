using UnityEngine;
using System.Collections;

public class Vegetable : Ingredients
{
	public enum Chopped
	{
		full = 0,
		half = 1,
		quarters = 2,
		eighths = 3,
		cubed = 4,
		diced = 5,
		annihilated = 6
	};

	public Chopped chopLevel;

	public Vegetable()
	{
		chopLevel = Chopped.full;
		Debug.Log("Default Vegetable Constructor Called");
	}

	public Vegetable(Type iType, Location iLocation)
	{
		itemType = iType;
		itemLocation = iLocation;
		movable = true;
		choppable = true;
		chopLevel = Chopped.full;
		Debug.Log("Vegetable Constructor Called");
	}
}
