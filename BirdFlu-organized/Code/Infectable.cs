using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infectable : MonoBehaviour {

	private float infectionlevel; // if this reaches 45 then game over (starts as 45 seconds of exposure then decreases)
	private float scaredlevel;
	private bool infecting;


	void FixedUpdate(){ // called 60 times a second(ish)
		if(infecting){ // adds the time of exposure since the last frame
			Debug.Log(infectionlevel);
			infectionlevel += Time.deltaTime *getInfectionMulti();
			scaredlevel += Time.deltaTime *getScareMulti();
		}

		if(scaredlevel > 45.0f ){
			setInfecting(false);
			 // make leave elevator
		}
		else if(infectionlevel > 45.0f){ // checks if the infected person is dead due to the 
			setInfecting(false);
			Debug.Log("end of game?");
			Application.Quit(); // change to restart level later
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

}