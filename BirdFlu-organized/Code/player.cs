using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private int desperation = 0; //if time
    private float pausetime = 0f;
    private bool peed = false;

    private int Index;
    private AudioSource source;
    private float volLowRange = 0.5f;
    private float volHighRange = 1.0f;

    private float phoneOpenCount = 0;
    private int clickCount = 0;

    [SerializeField]
    public AudioClip[] farts; // = new AudioClip[10];
    public AudioClip[] cough; // = new AudioClip[10];
    public AudioClip[] shout; // = new AudioClip[10];
    public AudioClip[] Noonoo; //= new AudioClip[4];
    public AudioClip[] sickSound; //= new AudioClip[4];
    public Animation[] phoneMSG; //= new Animation[3];
    public Animation phoneDead;
    public Animation sick;
    public GameObject pee;
    public Lift lift;


    void Start()
    {
        source = GetComponent<AudioSource>();
    }


    void FixedUpdate()
    { // called 60 times a second
        if (pausetime <= 0)
        {

            if (clickCount >= 7)
            {
                lift.setInfectionMulti(lift.getInfectionMulti() + 1f);
                lift.setScareMulti(lift.getScareMulti() + 5f);
                //screen shake ?
                clickCount = 0;
            }
            else if (Input.GetKeyUp("p") && !peed)
            {
                lift.setInfectionMulti(lift.getInfectionMulti() + 2f);
                lift.setScareMulti(lift.getScareMulti() + 7f);
                peed = true;
                var pees = Instantiate(pee, new Vector3(0, 0, 0), Quaternion.identity); //Wherever the player is
                pausetime = 3f;
            }
            else if (Input.GetKeyUp("f"))
            {   //open phone
                if (phoneOpenCount <= phoneMSG.Length)
                {
                    lift.setScareMulti(lift.getScareMulti() + (phoneOpenCount * 0.5f));
                    phoneMSG[(int)Mathf.Round(phoneOpenCount)].Play();           //???????
                    phoneOpenCount += 1f;
                    pausetime = phoneMSG[(int)Mathf.Round(phoneOpenCount)].clip.length;
                }
                else if (phoneOpenCount == phoneMSG.Length)
                {
                    phoneDead.Play();
                    pausetime = phoneDead.clip.length;
                }
                else
                {
                    Index = Random.Range(0, farts.Length - 1);
                    source.PlayOneShot(farts[Index], 1);
                    lift.setInfectionMulti(lift.getInfectionMulti() + 1f);
                    lift.setScareMulti(lift.getScareMulti() + 1f);
                    pausetime = 2f;
                }
            }

        }
        else if (Input.GetKeyUp("n"))
        {   //Say no

            lift.setInfectionMulti(lift.getInfectionMulti() + 0.5f);
            lift.setScareMulti(lift.getScareMulti() + 1.5f);
            Index = Random.Range(0, Noonoo.Length - 1);               //However many Noonoo sounds we have
            source.PlayOneShot(Noonoo[Index], 1);
            Debug.Log("Nono sound");
            pausetime = 2f;
        }
        else if (Input.GetKeyUp("c"))
        {
            lift.setInfectionMulti(lift.getInfectionMulti() + 0.5f);
            lift.setScareMulti(lift.getScareMulti() + 3f);
            Index = Random.Range(0, cough.Length - 1);               //However many cough sounds we have
            source.PlayOneShot(cough[Index], 1);
            Debug.Log("cough sound");
            pausetime = 3f;
        }
        else if (Input.GetKeyUp("s"))
        {
            lift.setInfectionMulti(lift.getInfectionMulti() + 0.5f);
            lift.setScareMulti(lift.getScareMulti() + 2f);
            Index = Random.Range(0, shout.Length - 1);               //However many shout sounds we have
            source.PlayOneShot(shout[Index], 1);
            Debug.Log("shout sound");
            pausetime = 2f;
        }
        else if (Input.GetKeyUp("v"))
        {
            lift.setInfectionMulti(lift.getInfectionMulti() + 6f);
            lift.setScareMulti(lift.getScareMulti() + 10f);
            Index = Random.Range(0, sickSound.Length - 1);               //However many retch sounds we have
            source.PlayOneShot(sickSound[Index], 1);
            sick.Play();
            Debug.Log("sick sound");
            pausetime = 7f;
        }
        pausetime -= Time.deltaTime;
        if(pausetime <= 0)
        {
            clickCount = 0;
        }
    }

    void OnMouseUp()
    {
        Debug.Log("On Mouse Up Event");
        clickCount += 1;
        CastRay();
    }

    void CastRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            Debug.DrawLine(ray.origin, hit.point);
            Debug.Log("Hit object: " + hit.collider.gameObject.name);
            if (hit.collider.gameObject.tag == "Interactable")
            {
                hit.collider.gameObject.GetComponent<Interactable>().effect();
                pausetime += 3f;     //constant reactivation time
            }
        }
    }
}