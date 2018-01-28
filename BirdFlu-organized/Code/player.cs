using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private int desperation = 0; //if time
    private float pausetime = 0f;
    private bool peed = false;
    var pee : GameObject;

    public int NoonooIndex; 
    private AudioSource source;
    private float volLowRange = 0.5f;
    private float volHighRange = 1.0f;

    private int phoneOpenCount = 0;

    [Serialized]
    public AudioClip[] Noonoo; //= new AudioClip[4];
    private Animation[] phoneMSG; //= new Animation[3];
    private Animation phoneDead;
    private Animation phoneDead;
    


    void Start ()
    {
        source = GetComponent<AudioSource>();
    }

	FixedUpdate(){ // called 60 times a second
        if(pausetime <= 0){
            if(Input.GetKeyUp("P") && !peed){
            setInfectionMulti(getInfectionMulti() + 2f);
            setScareMulti(getScareMulti() + 5f);
            peed = true;
            var pee = Instantiate(pee,new Vector3(0,0,0),Quaternion.indentity); //Wherever the player is
            pausetime = 3f;
        }
        else if(Input.GetKeyUp("F")){   //open phone
                if(phoneOpenCount <= phoneMSG.Length){
                    setScareMulti(getScareMulti() + (phoneOpenCount * 0.5f));
                    phoneMSG[(int)Math.Round(phoneOpenCount)].Play();           //???????
                    phoneOpenCount += 1f;
                    pausetime = phoneMSG[(int)Math.Round(phoneOpenCount)].clip.length;
                }
                else{
                    phoneDead.Play();
                    pausetime = phoneDead.clip.length;
                }
            }
            
        }
        else if(Input.GetKeyUp("N")){   //Say no
            setInfectionMulti(getInfectionMulti() + 0.5f);
            setScareMulti(getScareMulti() + 1.5f);
            NoonooIndex = Random.Range(0, 3);               //However many Noonoo sounds we have
            source.PlayOneShot(Noonoo[NoonooIndex], 1); 
        } 
		pausetime -= Time.deltaTime;
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
        	hit.collider.gameobject.effect();
            pausetime += 3f;     //constant reactivation time
        }
    }
}