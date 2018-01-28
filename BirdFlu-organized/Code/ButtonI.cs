using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button1 : Interactable {

	private AudioSource source;

	[Serialized]
	public GameObject lightSwitch;
	public AudioClip switch;
	public AudioClip break;


	void Start ()
    {
        source = GetComponent<AudioSource>();
    }

	public void activation(){ //as many parameters as needed for every case.
		source.PlayOneShot(switch, 1);
		lightSwitch.SetActive(!lightSwitch.activeSelf);
	}

	public  void endEffect(){ //what happens when interactions run out.
		source.PlayOneShot(break, 1);
	}
}
