using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infection : MonoBehaviour {

	void OnTriggerEnter (Collider col) {
        Debug.Log("Collision Enter");
		if(col.gameObject.tag == "Infectable") {
			col.gameObject.GetComponent<Infectable>().infect();
            print("INFECTION");
		}
	}

	void OnTriggerExit (Collider col) {
		if(col.gameObject.tag == "Infectable") {
			 col.gameObject.GetComponent<Infectable>().disinfect();
		}
	}
}
