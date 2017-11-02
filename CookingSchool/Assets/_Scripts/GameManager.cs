using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public Camera mainCamera;
	private cameraMovement camScript;

	private Items item;

	private bool holding;

	private Vector3 mousePos;
	private Vector3 newPos;
	private float zPos;

	// Use this for initialization
	void Start()
	{
		holding = false;
		camScript = mainCamera.GetComponent<cameraMovement>();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonDown(0) && !holding)
		{
			Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit))
			{
				if (hit.collider.CompareTag("Container") || hit.collider.CompareTag("Ingredient") || hit.collider.CompareTag("Tool"))
				{
					if (hit.collider.gameObject.GetComponent<Items>() != item)
					{
						item = hit.collider.gameObject.GetComponent<Items>();
						zPos = mainCamera.transform.position.z - item.gameObject.transform.position.z;
					}

					if ((int)item.itemLocation == camScript.camLocation || item.itemLocation == Items.Location.Inventory)
					{
						item.interactable = true;
					}

					if (item.interactable)
					{
						holding = true;
						Debug.Log("Clicked on whatever " + zPos);
					}
					else
					{
						item = null;
						Debug.Log("Item not interactable");
					}
				}
			}
		}
		else if (Input.GetMouseButtonDown(1))
		{
			if (holding)
			{
				holding = false;
				Debug.Log("Let go of whatever");
			}
		}

		if (holding)
		{
			if (item.movable)
			{
				mousePos = Input.mousePosition;
				mousePos.z = zPos;//1.2f;

				newPos = mainCamera.ScreenToWorldPoint(mousePos);
				//newPos.z = zPos;

				item.gameObject.transform.position = newPos;

				//Debug.Log(item.gameObject.transform.position.z);
			}
		}
	}
}
