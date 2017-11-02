using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tools : Items
{
	public Ingredients heldItem;

	public Tools()
	{
		Debug.Log("Default Container Constructor Called");
	}

	public Tools(Type iType, Location iLocation)
	{
		itemType = iType;
		itemLocation = iLocation;
		Debug.Log("Container Constructor Called");
	}
}
