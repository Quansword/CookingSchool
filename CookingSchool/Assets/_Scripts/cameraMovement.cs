using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.position = new Vector3(-7.5f, 1.65f, 6.75f);
        
    }
	
	// Update is called once per frame
	void Update () {
        //smoothMove(new Vector3(-4.51f, 1.65f, 1.72f));
    }

    void smoothMove(Vector3 targetPos)
    { 

        transform.position = Vector3.Lerp(transform.position, targetPos, 1.5f * Time.deltaTime);
    }
}
