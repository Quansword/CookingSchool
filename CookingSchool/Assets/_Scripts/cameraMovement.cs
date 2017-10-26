﻿using System.Collections;
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

        if (Input.anyKeyDown)
        {
            moveCoroutine = smoothMove(3);
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
            transform.position = Vector3.Lerp(transform.position, cameraPositions[index], 1.4f * Time.deltaTime);
            yield return null;
        }
        transform.position = cameraPositions[index];
    }
}
