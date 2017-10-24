using UnityEngine;
using System.Collections;

public class PanStuff : Ingredients
{
	public enum PSType
	{
		butter = 0,
		vOil = 1,
		oOil = 2,
		spray = 3
	};

	public PSType stuffType;

	public PanStuff()
	{
		stuffType = PSType.butter;
		choppable = true;
		measurable = true;
		clean = true;
		Debug.Log("Default PanStuff Constructor Called");
	}

	public PanStuff(Type iType, Location iLocation, PSType sType)
	{
		itemType = iType;
		itemLocation = iLocation;
		stuffType = sType;

		if (stuffType == PSType.butter)
		{
			choppable = true;
		}

		if (stuffType != PSType.spray)
		{
			measurable = true;
		}
		clean = true;
		Debug.Log("PanStuff Constructor Called");
	}
}
