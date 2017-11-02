using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public Camera mainCamera;
	private cameraMovement camScript;

	private Items item;
	private Containers hitContainer;
	private Ingredients hitIngredient;

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
						item.gameObject.GetComponent<Collider>().enabled = false;
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
		else if (Input.GetMouseButtonDown(0) && holding)
		{
			Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit))
			{
				if (item.itemType == Items.Type.Ingredients && hit.collider.CompareTag("Container"))
				{
					hitContainer = hit.collider.gameObject.GetComponent<Containers>();

					if (item.name == "spice")
					{
						hitContainer.salt++;
					}
					else if (item.name == "pepper")
					{
						hitContainer.pepper++;
					}
					else if (item.name == "milk carton")
					{
						hitContainer.milk++;
					}
					else
					{
						hitContainer.itemList.Add((Ingredients)item);
						item.gameObject.SetActive(false);
						holding = false;
					}
				}
				else if (item.itemType == Items.Type.Tools && hit.collider.CompareTag("Container"))
				{
					hitContainer = hit.collider.gameObject.GetComponent<Containers>();

					if (hitContainer.milk == 2 && hitContainer.itemList.Count == 4)
					{
						hitContainer.mixed = true;
						// TODO instantiate liquid egg and clear stuff from container
					}
				}
				else if (item.itemType == Items.Type.Container && hit.collider.CompareTag("Container"))
				{
					hitContainer = hit.collider.gameObject.GetComponent<Containers>();
					Debug.Log(hitContainer.name);

					hitContainer.salt += ((Containers)item).salt;
					hitContainer.salt += ((Containers)item).pepper;
					hitContainer.salt += ((Containers)item).milk;

					((Containers)item).salt = 0;
					((Containers)item).pepper = 0;
					((Containers)item).milk = 0;

					for (int i = ((Containers)item).itemList.Count - 1; i >= 0; i--)
					{
						hitContainer.itemList.Add(((Containers)item).itemList[i]);
						((Containers)item).itemList.RemoveAt(i);
					}
				}
				else if (item.itemType == Items.Type.Tools && hit.collider.CompareTag("Ingredient"))
				{
					hitIngredient = hit.collider.gameObject.GetComponent<Ingredients>();

					if (hitIngredient.name == "butter")
					{
						// TODO instantiate butter slice
					}
				}
			}
		}
		else if (Input.GetMouseButtonDown(1))
		{
			if (holding)
			{
				item.interactable = false;
				item.gameObject.GetComponent<Collider>().enabled = true;
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
