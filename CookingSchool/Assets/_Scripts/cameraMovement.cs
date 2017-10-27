using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour {

    // Use this for initialization
    private IEnumerator moveCoroutine;

    private Vector3[] cameraPositions = new Vector3[8];
    private Quaternion[] cameraRotations = new Quaternion[8];


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

    public int camLocation;

    void Start () {
        cameraPositions[0] = new Vector3(-7.5f, 1.65f, 6.75f);
        cameraRotations[0] = new Quaternion(0, 180, 0, 0);
        cameraPositions[1] = new Vector3(-4.46f, 1.72f, 1.84f);
        cameraRotations[1] = new Quaternion(0, 180, -17.693f, 1);
        cameraPositions[2] = new Vector3(-5.5f, 1.82f, 1.84f);
        cameraRotations[2] = new Quaternion(0, 180, -24.839f, 0);
        Vector3 temp = cameraPositions[1];
        for (int i=3;i<8;i++)
        {
            temp.x -= 1.0f;
            cameraPositions[i] = temp;
            cameraRotations[i] = cameraRotations[2];
        }
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonUp(0))
        {
            int posIndex=0;
            if (Input.mousePosition.x < Screen.width / 8 * 1)
            {
                posIndex = 1;
            }
            else if (Input.mousePosition.x < Screen.width / 8 * 2)
            {
                posIndex = 2;
            }
            else if (Input.mousePosition.x < Screen.width / 8 * 3)
            {
                posIndex = 3;
            }
            else if (Input.mousePosition.x < Screen.width / 8 * 4)
            {
                posIndex = 4;
            }
            else if (Input.mousePosition.x < Screen.width / 8 * 5)
            {
                posIndex = 5;
            }
            else if (Input.mousePosition.x < Screen.width / 8 * 6)
            {
                posIndex = 6;
            }
            else if (Input.mousePosition.x < Screen.width / 8 * 7)
            {
                posIndex = 7;
            }
            moveCoroutine = smoothMove(posIndex);
            StartCoroutine(moveCoroutine);
            transform.rotation = cameraRotations[posIndex];
            Debug.Log("Pressed a key");
        }
        
    }

    IEnumerator smoothMove(int index)
    {
        float startTime = Time.time;
        Debug.Log("Moving to position " + index);
        while (Time.time < startTime + 2f)
        {
            transform.position = Vector3.Lerp(transform.position, cameraPositions[index], 1.0f * Time.deltaTime);
            yield return null;
        }
        transform.position = cameraPositions[index];
    }
}
