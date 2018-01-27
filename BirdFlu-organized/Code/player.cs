using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	FixedUpdate(){ // called 60 times a second
			
	}

	void OnMouseUp() {
    	Debug.Log("On Mouse Up Event");
    	CastRay();
	}


	void CastRay() {
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    RaycastHit hit;
    if (Physics.Raycast(ray, out hit, 100)) {
        Debug.DrawLine(ray.origin, hit.point);
        Debug.Log("Hit object: " + hit.collider.gameobject.name);
        if(hit.collider.gameobject.tag == "Interactable"){
        	gameobject.effect();
        }
    }
}