using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Recipe : MonoBehaviour
{


    private List<string> recipeText = new List<string>();
    public Camera mainCamera;
    private cameraMovement cam;
    public Text screenText;
    public GameObject panel;
    public GameObject iText;

    private int index = 0;

    // Use this for initialization
    void Start()
    {
        cam = mainCamera.GetComponent<cameraMovement>();
        recipeText.Add("Cooking School");
        recipeText.Add("Ingredients:\n 4 eggs \n 1/4 cup whole milk \n 1 tablespoon butter \n salt and pepper(to taste) ");

        recipeText.Add("Crack eggs into mixing bowl and beat them until the mixture is a uniform a pale yellow ");
        recipeText.Add("Add Milk, Salt, and Pepper to the egg mixture");
        recipeText.Add("Whisk egg mixture thoroughly");
        recipeText.Add("Heat a non-stick pan over a low medium heat");
        recipeText.Add("Test the heat");
        recipeText.Add("Melt butter onto the pan");
        recipeText.Add("Pour eggs into the pan");
        recipeText.Add("Stir gently until all the liquid is gone");
        recipeText.Add("Turn off the heat");
        recipeText.Add("Transfer eggs onto a plate");


    }

    // Update is called once per frame
    void Update()
    {
        if(cam.camLocation == 0)
        {
            panel.SetActive(false);
            iText.SetActive(false);
        }
        else
        {
            panel.SetActive(true);
            iText.SetActive(true);
        }
        if (index == 12)
        {
            index = 0;
        }
    }
    public void nextStep()
    {
        screenText.text = recipeText[++index];
    }
    public void prevStep()
    {
        screenText.text = recipeText[--index];
    }
}
