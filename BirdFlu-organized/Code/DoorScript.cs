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
    private static float currentTime = 0f;  //Current time since it last mattered (counting interval)

    //private bool audioCue;  //Designates which door manages the audio, to prevent double looping of audio cues. Left door by default
    public AudioClip doorOpening;
    private float openingTime;
    public AudioClip doorClosing;
    private float closingTime; 
    private AudioSource source;

	// Use this for initialization
	void Start ()
    {
        source = GetComponent<AudioSource>();
        
        //Identify left and right doors
		if (doorID == true) //Left Door
        {
            doorOpenPos = 6;
            doorClosePos = 2.8f;
            doorCurrPos = 6;
            
            
        } else {    //Right Door
            doorOpenPos = -6;
            doorClosePos = -2.8f;
            doorCurrPos = -6;
        }
        doorMoveDis = doorOpenPos - doorClosePos;   //3.25

        //Get Sound Lengths, print them to log
        openingTime = doorOpening.length;   //This is a time of 2.75s
        closingTime = doorClosing.length;   //This is a time of 4.5s
        print(openingTime + " and " + closingTime);

        //Calculate doorMoveSpeed for opening and closing doors
        doorOpenSpeed = doorMoveDis / openingTime * Time.deltaTime;  //3.25 / 2.75
        doorCloseSpeed = doorMoveDis / closingTime * Time.deltaTime;
	}
	
	// Update is called once per frame
	void Update ()
    {
        currentTime += Time.deltaTime;
        if (Input.GetButtonDown("Jump"))
        {
            openStart();
        }
        if (Input.GetButtonDown("Fire3"))
        {
            closeStart();
        }

        if(doorState == true)
        {
            openDoor();
        } else
        {
            closeDoor();
        }

        transform.localPosition = new Vector3 (5.7f, 0, doorCurrPos);
    }

    void openStart()
    {
        doorState = true;
        source.PlayOneShot(doorOpening, 1); //Play Opening Sound
    }

    void closeStart()
    {
        doorState = false;
        source.PlayOneShot(doorClosing, 1); //Play Closing Sound
    }

    void openDoor()
    {
        if (Mathf.Abs(doorCurrPos) <= Mathf.Abs(doorOpenPos))
        {
            doorCurrPos += doorOpenSpeed;
            doorState = true;
            currentTime = 0;
        }
    }

    void closeDoor()
    {
        if (Mathf.Abs(doorCurrPos) >= Mathf.Abs(doorClosePos))
        {
            doorCurrPos -= doorCloseSpeed;
            doorState = false;
            currentTime = 0;
        }
    }

    public static float addTime(float f)
    {
        currentTime += f;
        return currentTime;
    }
}
