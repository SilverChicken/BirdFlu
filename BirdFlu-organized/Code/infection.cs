using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infection : MonoBehaviour {

	void OnCollisionEnter (Collision col) {
		if(col.gameObject.tag == "Infectable") {
			col.gameObject.GetComponent<Infectable>().infect();
		}
	}

	void OnCollisionExit (Collision col) {
		if(col.gameObject.tag == "Infectable") {
			 col.gameObject.GetComponent<Infectable>().disinfect();
		}
	}
}
