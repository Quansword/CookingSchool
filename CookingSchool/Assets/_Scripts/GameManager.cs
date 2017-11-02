using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public Camera mainCamera;
	private cameraMovement camScript;

	private Items item;
	private Containers hitContainer;
	private Ingredients hitIngredient;
    private List<Items> inventory = new List<Items>();
    private List<float> zPositions = new List<float>();

	private bool holding;

	private Vector3 mousePos;
    private Vector3 camPos;
	private Vector3 newPos;
	private float zPos;
    private float invY;
    private bool isStoveOn;
    private float startTime;
    private float endTime;
    private int cookedIndex;
    private bool isCooking;


    public GameObject panText;
	public Items liquidEgg;
    public Items[] cookedStatus = new Items[3];
	public PanStuff butterSlice;

	// Use this for initialization
	void Start()
	{
		holding = false;
        isStoveOn = false;
        isCooking = false;
        startTime = 0;
        endTime = 0;
        cookedIndex = -1;
		camScript = mainCamera.GetComponent<cameraMovement>();
        invY = camScript.cameraPositions[4].y+0.3f;
        panText.SetActive(false);
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
				if ((hit.collider.CompareTag("Container") || hit.collider.CompareTag("Ingredient") || hit.collider.CompareTag("Tool")) && (hit.collider.gameObject.name != "fry" || cookedIndex !=0))
				{
					if (hit.collider.gameObject.GetComponent<Items>() != item)
					{
						item = hit.collider.gameObject.GetComponent<Items>();
						zPos = mainCamera.transform.position.z - item.gameObject.transform.position.z;

						if (item.name == "fry")
						{
							zPos = mainCamera.transform.position.z - 0.7f;
						}
					}

					if ((int)item.itemLocation == camScript.camLocation || item.itemLocation == Items.Location.Inventory)
					{
						if (item.name == "fry")
						{
							item.transform.rotation = Quaternion.Euler(0f, -45f, 0f);
						}
						else if (item.name == "whisk")
						{
							item.transform.rotation = Quaternion.Euler(-5.17f, -1.634f, -162.434f);
						}
						else if (item.name == "spat")
						{
							item.transform.rotation = Quaternion.Euler(-1.05f, 128.67f, 86.058f);
						}
						else if (item.name == "butter knife")
						{
							item.transform.rotation = Quaternion.Euler(85, 345, 275);
						}

                        item.interactable = true;
                        item.gameObject.GetComponent<Collider>().enabled = false;
                        if(item.itemLocation == Items.Location.Inventory)
                        {
                            item.itemLocation = (Items.Location)camScript.camLocation;
                            int i = 0;
                            foreach (Items thing in inventory)
                            {
                                if(thing.name == item.name)
                                {
                                    break;
                                }
                                i++;
                            }
                            inventory.Remove(item);
                            zPos = zPositions[i];
                            zPositions.RemoveAt(i);
                        }
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
						hitContainer.salt = 0;
						hitContainer.pepper = 0;
						hitContainer.milk = 0;
						
						for (int i = 0; i < 4; i++)
						{
							hitContainer.itemList.RemoveAt(0);
						}

						Items liquid = Instantiate(liquidEgg, hitContainer.transform.position, hitContainer.transform.rotation, hitContainer.gameObject.transform);
						liquid.itemLocation = (Items.Location)camScript.camLocation;
						liquid.transform.localScale = new Vector3(0.054f, 0.054f, 0.054f);
					}
				}
				else if (item.itemType == Items.Type.Container && hit.collider.CompareTag("Container"))
				{
					hitContainer = hit.collider.gameObject.GetComponent<Containers>();
					Debug.Log(hitContainer.name);

					hitContainer.salt += ((Containers)item).salt;
					hitContainer.pepper += ((Containers)item).pepper;
					hitContainer.milk += ((Containers)item).milk;

					((Containers)item).salt = 0;
					((Containers)item).pepper = 0;
					((Containers)item).milk = 0;

					for (int i = ((Containers)item).itemList.Count - 1; i >= 0; i--)
					{
						hitContainer.itemList.Add(((Containers)item).itemList[i]);
						((Containers)item).itemList.RemoveAt(i);
					}

					if (((Containers)item).mixed)
					{
						Destroy(item.gameObject.transform.GetChild(0).gameObject);
						Items liquid = Instantiate(liquidEgg, hitContainer.transform.position, hitContainer.transform.rotation, hitContainer.gameObject.transform);
						liquid.itemLocation = (Items.Location)camScript.camLocation;
						newPos = liquid.transform.localPosition;
						newPos.y += 0.03f;
						liquid.transform.localPosition = newPos;

                        panText.SetActive(false);
                        isCooking = true;
                        startTime = Time.realtimeSinceStartup;
                        endTime = startTime + 10;
                        cookedIndex = 0;
					}

                    if (((Containers)item).name == "fry" && cookedIndex >= 0)
                    {
                        isCooking = false;
                        Items food = Instantiate(cookedStatus[cookedIndex - 1], hitContainer.transform.position, hitContainer.transform.rotation, hitContainer.gameObject.transform);
                        Destroy(item.gameObject.transform.GetChild(3).gameObject);
                        
                        food.itemLocation = (Items.Location)camScript.camLocation;
                        food.transform.localScale = new Vector3(1f, 1f, 1f);
                    }
				}
				else if (item.itemType == Items.Type.Tools && hit.collider.CompareTag("Ingredient"))
				{
					hitIngredient = hit.collider.gameObject.GetComponent<Ingredients>();

					if (hitIngredient.name == "butter")
					{
						PanStuff butter = Instantiate(butterSlice, hitIngredient.transform.position, hitIngredient.transform.rotation);
						butter.itemLocation = Items.Location.Cutting;
						newPos = butter.transform.position;
						newPos.z += 0.1f;
						butter.transform.position = newPos;
					}
				}
			}
		}
		else if (Input.GetMouseButtonDown(1) && Input.mousePosition.x<Screen.width/10)
		{
			if (holding && (item.itemType == Items.Type.Container || item.itemType == Items.Type.Ingredients) )
			{
				item.interactable = false;
                item.itemLocation = Items.Location.Inventory;
                zPositions.Add(zPos);
                inventory.Add(item);
				item.gameObject.GetComponent<Collider>().enabled = true;
				holding = false;
				Debug.Log("Let go of whatever");
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

                if (item.name == "fry")
                {
                    startTime = Time.realtimeSinceStartup;
                    endTime = startTime + 10;
                }
				else if (item.name == "whisk")
				{
					item.transform.rotation = Quaternion.Euler(0, 0, -90f);
				}
				else if (item.name == "spat")
				{
					item.transform.rotation = Quaternion.Euler(0, 0, 0);
				}
				else if (item.name == "butter knife")
				{
					item.transform.rotation = Quaternion.Euler(0, 90, 0);
				}
			}
        }
        invY = -0.2f;
        foreach (Items invItem in inventory)
        {
            camPos = mainCamera.transform.position;
            camPos.z -= 1;
            camPos.x += 0.6f;
            camPos.y += invY + 0.3f;
            invItem.gameObject.transform.position = camPos;
            invY -= 0.2f;
           
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
        if(Time.realtimeSinceStartup >= endTime && !isCooking && isStoveOn)
        {
            panText.SetActive(true);
            endTime = 0;
            startTime = 0;
        }
        if(isCooking)
        {
            if(Time.realtimeSinceStartup >= endTime)
            {
				if (cookedIndex != 3)
				{
					Destroy(hitContainer.gameObject.transform.GetChild(3).gameObject);
					Items scrambledEggs = Instantiate(cookedStatus[cookedIndex], hitContainer.transform.position, hitContainer.transform.rotation, hitContainer.gameObject.transform);
					scrambledEggs.itemLocation = (Items.Location)camScript.camLocation;
					newPos = scrambledEggs.transform.localPosition;
					newPos.y += 0.03f;
					scrambledEggs.transform.localPosition = newPos;
				}

                if(cookedIndex < 3)
                {
                    cookedIndex++;
                    if(cookedIndex == 1)
                    {
                        endTime += 10;
                    }
                    else if(cookedIndex == 2)
                    {
                        endTime += 10;
                    }
                }
               
            }
        }
	}
    public void stoveOn()
    {
        isStoveOn = true;
    }
    public void stoveOff()
    {
        isStoveOn = false;
    }
}
