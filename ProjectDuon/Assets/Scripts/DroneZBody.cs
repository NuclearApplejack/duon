using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneZBody : MonoBehaviour {

    public AudioSource audioS;
    public AudioClip soundEffect;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlaySound()
    {
        audioS.PlayOneShot(soundEffect);
    }
}
