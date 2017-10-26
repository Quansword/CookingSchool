using UnityEngine;
using System.Collections;

public class Containers : Items
{
	public bool inUse;
	public bool mixed;

	public List<Ingredients> itemList = new List<Ingredients>();

	public Containers()
	{
		inUse = false;
		mixed = false;
		Debug.Log("Default Container Constructor Called");
	}

	public Containers(Type iType, Location iLocation)
	{
		itemType = iType;
		itemLocation = iLocation;
		inUse = false;
		mixed = false;
		Debug.Log("Container Constructor Called");
	}
}
