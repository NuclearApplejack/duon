using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Antony : Interactable {

    // Use this for initialization
    new void Start () {
        base.Start();

        inspectPrompt = Instantiate(Resources.Load("Prefabs/InspectPrompt")) as GameObject;
        inspectPrompt.transform.position = new Vector3(transform.position.x, transform.position.y + 10, -9);
    }
	
	// Update is called once per frame
	new void Update () {
        base.Update();

        if (mark.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }


    public override void CheckIfPlayerIsInRange()
    {
        if (generalManager.GetComponent<DimensionManager>().currentDimension != Dimension.DIMENSION_A)
        {
            playerIsInRange = false;
            return;
        }

        if (mark.transform.position.x > transform.position.x - 2 && mark.transform.position.x < transform.position.x + 2)
        {
            playerIsInRange = true;
        }
        else
        {
            playerIsInRange = false;
        }
    }

    public override void PerformInteraction()
    {
        if (GlobalHolder.stage1Complete)
        {
            generalManager.GetComponent<DialogueManager>().QueueDialogueFile("Dia Main Lab Antony 2");
        }
        else
        {
            generalManager.GetComponent<DialogueManager>().QueueDialogueFile("Dia Main Lab Antony 1");
        }
    }
}
