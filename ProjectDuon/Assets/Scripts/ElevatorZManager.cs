using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorZManager : MonoBehaviour {

    public AudioSource audioS;
    public AudioClip sound1;
    public AudioClip sound2;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlaySound1()
    {
        audioS.PlayOneShot(sound1);
    }

    public void PlaySound2()
    {
        audioS.PlayOneShot(sound2);
    }

}
