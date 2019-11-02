using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryMovieController : MonoBehaviour {

    public StoryManager manager;

    public AudioClip aClip;
    public AudioSource aSource;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Transition()
    {
        manager.Transition();
    }

    public void PlayAudio()
    {
        aSource.PlayOneShot(aClip, 2f);
    }


}
