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
    private float floorTime; //Time taken between floors
    private float levelTime; //Time taken in level
    private float currentTime = 0f; //Current time since it last mattered (counting interval)

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
        openingTime = doorOpening.length;   //This is a time of 2.75s
        closingTime = doorClosing.length;   //This is a time of 4.5s
        print(openingTime + " and " + closingTime);

        //Calculate doorMoveSpeed for opening and closing doors
        doorOpenSpeed = doorMoveDis / openingTime * Time.deltaTime;
        doorCloseSpeed = doorMoveDis / closingTime * Time.deltaTime;
	}
	
	// Update is called once per frame
	void Update ()
    {
    	currentTime += Time.deltaTime;
        if (currentTime >= floorTime && doorState == false)
        {
            doorState = true;
            source.PlayOneShot(doorOpening, 1); //Play Opening Sound
            currentTime = 0;
        }
        if (currentTime >= floorTime && doorState == true)
        {
            doorState = false;
            source.PlayOneShot(doorClosing, 1); //Play Closing Sound
            currentTime = 0;
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
        }
    }

    void closeDoor()
    {
        if (Mathf.Abs(doorCurrPos) >= Mathf.Abs(doorClosePos))
        {
            doorCurrPos -= doorCloseSpeed;
        }
    }
}
