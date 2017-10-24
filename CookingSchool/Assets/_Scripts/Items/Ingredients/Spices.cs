using UnityEngine;
using System.Collections;

public class Spices : Ingredients
{
	public Spices()
	{
		measurable = true;
		clean = true;
		Debug.Log("Default Spices Constructor Called");
	}

	public Spices(Type iType, Location iLocation)
	{
		itemType = iType;
		itemLocation = iLocation;
		measurable = true;
		clean = true;
		Debug.Log("Spices Constructor Called");
	}
}
