using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Containers : Items
{
	public bool mixed;
	public int salt;
	public int pepper;
	public int milk;

	public List<Ingredients> itemList = new List<Ingredients>();
}
