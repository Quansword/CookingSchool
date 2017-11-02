using UnityEngine;
using System.Collections;

public class Items : MonoBehaviour
{
	public enum Type
	{
		Ingredients = 0,
		Tools = 1,
		Container = 2,
		Food = 3
	};

	public enum Location
	{
		Kitchen = 0,
		Fridge = 1,
		Inventory = 2,
		Sink = 3,
		Cutting = 4,
		Prep = 5,
		Stove = 6,
		Plating = 7
	};

	public Type itemType;
	public Location itemLocation;
	public bool clean;
	public bool held;
	public bool interactable;
	public bool movable;
	public bool inUse;

	public Items()
	{
		itemType = Type.Ingredients;
		itemLocation = Location.Fridge;
		clean = false;
		held = false;
		interactable = false;
		movable = false;
		inUse = false;
		Debug.Log("Default Items Constructor Called");
	}

	//This is the constructor for the Items class
	//and is not inherited by any derived classes.
	public Items(Type iType, Location iLocation)
	{
		itemType = iType;
		itemLocation = iLocation;
		clean = false;
		held = false;
		interactable = false;
		movable = false;
		inUse = false;
		Debug.Log("Items Constructor Called");
	}
}
