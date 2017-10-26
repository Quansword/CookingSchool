using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour {

    // Use this for initialization
    private IEnumerator moveCoroutine;
    private Vector3[] cameraPositions = new Vector3[8];
	void Start () {
        cameraPositions[0] = new Vector3(-7.5f, 1.65f, 6.75f);
        cameraPositions[1] = new Vector3(-5.51f, 1.65f, 1.72f);
        Vector3 temp = cameraPositions[1];
        for (int i=2;i<8;i++)
        {
            temp.x -= 0.85f;
            cameraPositions[i] = temp;
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
        
    }
}
