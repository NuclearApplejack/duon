using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour {

    public bool playerIsInRange = false;
    public GameObject luna;
    public GameObject mark;
    public GameObject generalManager;

    public GameObject inspectPrompt;

    // Use this for initialization
    public void Start () {
        generalManager = GameObject.Find("GeneralManager");
        luna = GameObject.Find("Luna");
        mark = GameObject.Find("Mark");
    }
	
	// Update is called once per frame
	public void Update () {

        CheckIfPlayerIsInRange();
        inspectPrompt.GetComponent<InspectPromptController>().active = playerIsInRange;
        if (playerIsInRange)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && !generalManager.GetComponent<PauseManager>().IsPaused() && !generalManager.GetComponent<EventIssuer>().EventsAreOn())
            {
                PerformInteraction();
            }
        }
	}

    public abstract void CheckIfPlayerIsInRange();

    public abstract void PerformInteraction();
}
