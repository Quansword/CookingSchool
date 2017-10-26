using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tools : Items
{
	public bool inUse;

	public Ingredients heldItem;

	public Tools()
	{
		inUse = false;
		Debug.Log("Default Container Constructor Called");
	}

	public Tools(Type iType, Location iLocation)
	{
		itemType = iType;
		itemLocation = iLocation;
		inUse = false;
		Debug.Log("Container Constructor Called");
	}
}
