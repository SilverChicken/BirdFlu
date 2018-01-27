using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour {

	private float infectionMulti;
	private float scareMulti;
	public bool isClosed;
	private float timeToClose;

	void FixedUpdate(){
		if(infectionMulti > 1){
			infectionMulti -= 0.0008f;
		}
		if(scareMulti > 1){
			infectionMulti -= 0.0012f;
		}

	}


	public float getInfectionMulti(){
		return infectionMulti;
	}

	public float getScareMulti(){
		return scareMulti;
	}

	public void setInfectionMulti(float I){
		infectionMulti = I;
	}

	public void setScareMulti(float S){
		scareMulti = S;
	}
}