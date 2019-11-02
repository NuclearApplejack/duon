﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GauntletDisplayA : Interactable
{

    // Use this for initialization
    new void Start()
    {
        base.Start();

        inspectPrompt = Instantiate(Resources.Load("Prefabs/InspectPrompt")) as GameObject;
        inspectPrompt.transform.position = new Vector3(transform.position.x, transform.position.y, -9);
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
        generalManager.GetComponent<DialogueManager>().QueueDialogueFile("Dia Main Lab Gauntlets A");
    }
}
