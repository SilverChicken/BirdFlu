using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infectable : MonoBehaviour {

	private int infectionlevel;
	private bool infecting;

	FixedUpdate(){ // called 60 times a second
		if(infecting){
			infectionlevel++;
		}
		// checks if the infected person is dead due to the 	
		if(infectionlevel > 2700){
			Application.Quit(); // change to restart level later
		}
	}


	public void infect(){
		Debug.Log("infection has begun");
		setInfecting(true);
	}

	public void disinfect(){
		setInfecting(false);
	}

	private void setInfecting(bool newVal){
		infecting = newVal;
	}
}