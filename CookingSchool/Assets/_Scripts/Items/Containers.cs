using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Containers : Items
{
	public bool inUse;
	public bool mixed;
	private int salt;
	private int pepper;
	private int milk;

	public List<Ingredients> itemList = new List<Ingredients>();

	public Containers()
	{
		inUse = false;
		mixed = false;
		salt = 0;
		pepper = 0;
		milk = 0;
		Debug.Log("Default Container Constructor Called");
	}

	public Containers(Type iType, Location iLocation)
	{
		itemType = iType;
		itemLocation = iLocation;
		inUse = false;
		mixed = false;
		salt = 0;
		pepper = 0;
		milk = 0;
		Debug.Log("Container Constructor Called");
	}
}
