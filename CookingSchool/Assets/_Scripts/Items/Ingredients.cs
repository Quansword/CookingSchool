using UnityEngine;
using System.Collections;

public class Ingredients: Items
{
	public bool choppable;
	public bool measurable;

	public Ingredients()
	{
		choppable = false;
		measurable = false;
		Debug.Log("Default Ingredients Constructor Called");
	}

	public Ingredients(Type iType, Location iLocation)
	{
		itemType = iType;
		itemLocation = iLocation;
		choppable = false;
		measurable = false;
		Debug.Log("Ingredients Constructor Called");
	}
}
