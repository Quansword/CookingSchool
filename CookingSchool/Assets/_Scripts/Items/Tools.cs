using UnityEngine;
using System.Collections;

public class Tools : Items
{
	public bool inUse;

	public List<Ingredients> itemList = new List<Ingredients>();

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
