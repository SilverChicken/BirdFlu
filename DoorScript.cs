using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {

    public bool doorID;     //True if Left, False if Right
    private float doorOpenPos;  //Door's Open Position. On opposing sides of origin
    private float doorClosePos; //Door's Closed Position. On opposing sides of the origin
    private float doorMoveDis;  //Range of movement on the doors, range between open and closed positions
    public float doorCurrPos;   //Door's Current Position, on the range of MoveDis
    public bool doorState;  //True if Open, False if Closed
    private float doorOpenSpeed;    //How fast the doors open
    private float doorCloseSpeed;   //How fast the doors close

    private bool audioCue;  //Designates which door manages the audio, to prevent double looping of audio cues. Left door by default
    public AudioClip doorOpening;
    private float openingTime;
    public AudioClip doorClosing;
    private float closingTime; 
    private AudioSource source;
    private float volLowRange = 0.5f;
    private float volHighRange = 1.0f;

	// Use this for initialization
	void Start ()
    {
        source = GetComponent<AudioSource>();
        
        //Identify left and right doors
		if (doorID == true) //Left Door
        {
            doorOpenPos = 6;
            doorClosePos = 2.75f;
            
            
        } else {    //Right Door
            doorOpenPos = -6;
            doorClosePos = -2.75f;
        }
        doorMoveDis = doorOpenPos - doorClosePos;

        //Get Sound Lengths, print them to log
        openingTime = doorOpening.length;
        closingTime = doorClosing.length;
        print(openingTime + " and " + closingTime);

        //Calculate doorMoveSpeed for opening and closing doors
        doorOpenSpeed = doorMoveDis / openingTime;
        doorCloseSpeed = doorMoveDis / closingTime;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("Jump"))
        {
            doorState = true;
            source.PlayOneShot(doorOpening, 1); //Play Opening Sound
        }
        if (Input.GetButtonDown("Fire3"))
        {
            doorState = false;
            source.PlayOneShot(doorClosing, 1); //Play Closing Sound
        }

        if(doorState == true)
        {
            openDoor();
        } else
        {
            closeDoor();
        }

        transform.localPosition = new Vector3 (7, 4, doorCurrPos);
    }

    void openDoor()
    {
        if (Mathf.Abs(doorCurrPos) <= Mathf.Abs(doorOpenPos))
        {
            doorCurrPos += doorOpenSpeed;
            doorState = true;
        }
    }

    void closeDoor()
    {
        if (Mathf.Abs(doorCurrPos) >= Mathf.Abs(doorClosePos))
        {
            doorCurrPos -= doorCloseSpeed;
            doorState = false;
        }
    }
}
