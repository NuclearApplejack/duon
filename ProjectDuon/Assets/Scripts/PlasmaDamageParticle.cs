using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaDamageParticle : GeneralParticle {

	// Use this for initialization
	void Start () {
        GetComponent<Animator>().SetInteger("RandNum", 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DestroyParticle()
    {
        Destroy(gameObject);
    }
}
