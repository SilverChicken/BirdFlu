using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {

    public bool doorID;     //True if Left, False if Right
    private float doorOpenPos;  //Door's Open Position. On opposing sides of origin
    private float doorClosePos; //Door's Closed Position. On opposing sides of the origin
    public float doorCurrPos;   //Door's Current Position, range between Open and Closed Positions
    public bool doorState;  //True if Open, False if Closed

	// Use this for initialization
	void Start ()
    {
		if (doorID == true)
        {
            doorOpenPos = 6;
            doorClosePos = 2.75f;
        } else {
            doorOpenPos = -6;
            doorClosePos = -2.75f;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("Jump"))
        {
            openDoor();
        }
        if (Input.GetButtonDown("Fire3"))
        {
            closeDoor();
        }
        transform.localPosition = new Vector3 (7, 4, doorCurrPos);
    }

    void openDoor()
    {
        if (doorCurrPos != doorOpenPos)
        {
            doorCurrPos = doorOpenPos;
            doorState = true;
        }
    }

    void closeDoor()
    {
        if (doorCurrPos != doorClosePos)
        {
            doorCurrPos = doorClosePos;
            doorState = false;
        }
    }
}
