using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

	private bool isActive;
	private int maxActivations;
	public float infectiness; // Constant that a particular item adds to the rate of infection in the elevator
	public float scaryness; // Constant that a particular item adds to how well you're scary people off


	public void effect(){
		if(isActive){
			if(maxActivations > 0){		//Does the invisible meters stuff and activation numbers
				maxActivations--;
				infectionMulti += infectiness;
				scary += scaryness;
				activation();						//Does the specific animation and activation for the object
			}
			else{
				endEffect();
				isActive = false;
			}
		}
	}


	//next two functions need to be specific to each different interaction.

	abstract void activation(){ //as many parameters as needed for every case.

	}

	abstract void endEffect(){ //what happens when interactions run out.

	}

}