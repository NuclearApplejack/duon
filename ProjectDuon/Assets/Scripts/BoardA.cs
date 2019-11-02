using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardA : Interactable
{

    // Use this for initialization
    new void Start()
    {
        base.Start();

        inspectPrompt = Instantiate(Resources.Load("Prefabs/InspectPrompt")) as GameObject;
        inspectPrompt.transform.position = new Vector3(transform.position.x, transform.position.y + 6, -9);

        if (GlobalHolder.stage1Complete)
        {
            GetComponent<Animator>().SetTrigger("Clear10");
        }
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
    }

    public override void CheckIfPlayerIsInRange()
    {
        if (generalManager.GetComponent<DimensionManager>().currentDimension != Dimension.DIMENSION_A)
        {
            playerIsInRange = false;
            return;
        }

        if (mark.transform.position.x > transform.position.x - 8 && mark.transform.position.x < transform.position.x + 8)
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
            generalManager.GetComponent<DialogueManager>().QueueDialogueFile("Dia Main Lab Board A 2");
        }
        else
        {
            generalManager.GetComponent<DialogueManager>().QueueDialogueFile("Dia Main Lab Board A 1");
        }
    }
}
