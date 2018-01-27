using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    private Vector3 moveDirection = Vector3.zero;
    private float moveSpeed = 1.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.W))
        {
            moveDirection = new Vector3(0.0f, Input.GetAxis("Vertical"), 0.0f);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= moveSpeed;
        } if (Input.GetKey(KeyCode.S))
        {

        }
	}
}
