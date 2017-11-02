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
}
