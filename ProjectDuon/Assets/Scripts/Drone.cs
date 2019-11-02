using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : Interactable {

    Animator animatorA;
    Animator animatorZ;
    bool animPlayed = false;


	// Use this for initialization
	new void Start () {
        base.Start();
        inspectPrompt = Instantiate(Resources.Load("Prefabs/InspectPrompt")) as GameObject;
        inspectPrompt.transform.position = new Vector3(transform.position.x, transform.position.y + 8, -9);
        //animatorA = transform.Find("Drone A Body").GetComponent<Animator>();
        animatorZ = transform.Find("Drone Z Body").GetComponent<Animator>();

    }
	
	// Update is called once per frame
	new void Update () {
        base.Update();
        if (playerIsInRange)
        {

            if (!animPlayed)
            {
                //animatorA.SetTrigger("activate");
                animatorZ.SetTrigger("activate");
            }
            animPlayed = true;
            
            
        }
        else
        {
            animPlayed = false;
        }

	}

    public override void CheckIfPlayerIsInRange()
    {
        if (generalManager.GetComponent<DimensionManager>().currentDimension == Dimension.DIMENSION_A)
        {
            if (mark.transform.position.x >= transform.position.x - 2 && mark.transform.position.x <= transform.position.x + 2 && mark.transform.position.y >= transform.position.y - 4 && mark.transform.position.y <= transform.position.y - 1)
            {
                playerIsInRange = true;
                return;
            }
        }
        else
        {
            if (luna.transform.position.x >= transform.position.x - 2 && luna.transform.position.x <= transform.position.x + 2 && luna.transform.position.y >= transform.position.y - 4 && luna.transform.position.y <= transform.position.y - 1)
            {
                playerIsInRange = true;
                return;
            }
        }
        
        playerIsInRange = false;

    }

    public override void PerformInteraction()
    {

         List<DialogueLine> text = new List<DialogueLine>();
         text.Add(new DialogueLine("Checkpoint reached."));
         generalManager.GetComponent<DialogueManager>().GenerateDialogue(text);
        GlobalHolder.stage1Checkpoint = true;
         
    }

}
