using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infectable : MonoBehaviour {

	private float infectionlevel; // if this reaches 45 then game over (starts as 45 seconds of exposure then decreases)
	private bool infecting;
	private int currentDestination;
	private Vector3 nextPosition;
	private Rigidbody rigid;

	[SerializeField]
	private GameObject[] waypoints;

	[SerializeField]
	private float jumpMulti = 10.0f;

	void Start(){
		currentDestination = 0;
		infecting = false;
		infectionlevel = 0.0f;
		setDestination();
		rigid = this.GetComponent<Rigidbody>();
	}

	void FixedUpdate(){ // called 60 times a second(ish)
		if(infecting){ // adds the time of exposure since the last frame
			infectionlevel += Time.deltaTime * getInfectionMulti();
		}

		// checks if the infected person is dead due to the 	
		if(infectionlevel > 45.0f){
			setInfecting(false);
			Debug.Log("end of game?");
			Application.Quit(); // change to restart level later
		}

		// getting speed for use of adding forces on collision

	}

	void OnCollisionEnter (Collision col) {
		if(col.gameObject.tag == "waypoint1" && currentDestination != (waypoints.Length-1)) {
			currentDestination++;
			setDestination();
		}
		if(col.gameObject.tag == "floor") {
    		this.GetComponent<Rigidbody>().AddRelativeForce((Vector3.up + Vector3.forward) * 125f);
    	}
	}

	public void infect(){
		Debug.Log("infection has begun");
		setInfecting(true);
	}

	public void disinfect(){
		infectionlevel = 0;
		setInfecting(false);
	}

	private void setInfecting(bool newVal){
		infecting = newVal;
	}

	float getInfectionMulti(){
		return 1.0f;
	}

	void setDestination(){
		Debug.Log("clamity");
		Debug.Log("current destination array number:" + currentDestination);
		nextPosition = waypoints[currentDestination].transform.position;
		this.transform.LookAt(nextPosition);
	}
}