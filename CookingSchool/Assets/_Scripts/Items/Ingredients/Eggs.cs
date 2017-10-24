using UnityEngine;
using System.Collections;

public class Eggs : Ingredients
{
	public enum Cracked
	{
		uncracked = 0,
		correctly = 1,
		broken = 2
	};

	public Cracked howCracked;

	public Eggs()
	{
		clean = true;
		howCracked = 0;
		Debug.Log("Default Spices Constructor Called");
	}

	public Eggs(Type iType, Location iLocation)
	{
		itemType = iType;
		itemLocation = iLocation;
		clean = true;
		howCracked = 0;
		Debug.Log("Spices Constructor Called");
	}
}
