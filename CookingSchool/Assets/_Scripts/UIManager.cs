using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{


    private List<string> recipeText = new List<string>();
    public Camera mainCamera;
    private cameraMovement cam;
    public Text screenText;
    public GameObject[] objects = new GameObject[11];
    private bool flameOn;

    private int index = 0;

    // Use this for initialization
    void Start()
    {
        cam = mainCamera.GetComponent<cameraMovement>();
        recipeText.Add("Cooking School");
        recipeText.Add("Ingredients:\n 4 eggs \n 1/4 cup whole milk \n 1 tablespoon butter \n salt and pepper(to taste) ");

        recipeText.Add("Crack eggs into mixing bowl ");
        recipeText.Add("Add Milk, Salt, and Pepper to the egg mixture");
        recipeText.Add("Whisk egg mixture thoroughly\n\n Whisk: to mix a liquid quickly with a fork to make the eggs fluffy");
        recipeText.Add("Heat a non-stick pan over a low medium heat");
        recipeText.Add("Test the heat");
        recipeText.Add("Melt butter onto the pan");
        recipeText.Add("Pour eggs into the pan");
        recipeText.Add("Stir gently until all the liquid is gone");
        recipeText.Add("Turn off the heat");
        recipeText.Add("Transfer eggs onto a plate");
        flameOn = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(cam.camLocation == 0)
        {
            for (int i = 0; i < 11; i++)
            {
                objects[i].SetActive(false);

            }
        }
        
        else
        {
            for (int i = 0; i < 5; i++)
            {
                objects[i].SetActive(true);

            }
        }
        if (cam.camLocation == 6 && !flameOn)
        {
            objects[5].SetActive(true);
        }
        if(cam.camLocation != 6 && !flameOn)
        {
            objects[5].SetActive(false);
        }
        if (index == 12)
        {
            index = 0;
        }
    }
    public void nextStep()
    {
        ++index;
        if (index > 11) { index = 11; }
        screenText.text = recipeText[index];
    }
    public void prevStep()
    {
        --index;
        if (index < 0) { index = 0; }
        screenText.text = recipeText[index];
    }

    public void turnOnStove()
    {
        objects[5].SetActive(false);
        flameOn = true;
        for (int i = 6;i<10;i++)
        {
            objects[i].SetActive(true);
        }
    }
    public void selectOption()
    {
        for (int i = 6; i < 10; i++)
        {
            objects[i].SetActive(false);
        }
        objects[10].SetActive(true);
    }
}
