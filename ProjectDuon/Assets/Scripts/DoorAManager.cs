using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAManager : MonoBehaviour {

    public AudioSource audioS;
    public AudioClip sound1;

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
}
