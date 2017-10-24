using UnityEngine;
using System.Collections;

public class Liquids : Ingredients
{
	public Liquids()
	{
		measurable = true;
		clean = true;
		Debug.Log("Default Liquids Constructor Called");
	}

	public Liquids(Type iType, Location iLocation)
	{
		itemType = iType;
		itemLocation = iLocation;
		measurable = true;
		clean = true;
		Debug.Log("Liquids Constructor Called");
	}
}
