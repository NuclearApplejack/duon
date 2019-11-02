using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtEffectController : MonoBehaviour {

    public AudioClip shine;

	// Use this for initialization
	void Start () {
        GameObject.Find("GeneralManager").GetComponent<DimensionManager>().GetCurrentCharacter().GetComponent<AudioSource>().PlayOneShot(shine, 1.8f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DestroyFX()
    {
        Destroy(gameObject);
    }
}
