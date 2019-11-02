using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectPromptController : MonoBehaviour {

    Animator animator;
    public bool active = false;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        animator.SetBool("InspectIsOn", active);
	}
}
