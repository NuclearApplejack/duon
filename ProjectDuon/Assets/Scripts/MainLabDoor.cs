using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLabDoor : Interactable {

    GameObject stageSpecificManager;

    // Use this for initialization
    new void Start () {
        base.Start();

        stageSpecificManager = GameObject.Find("StageSpecificManager");
        inspectPrompt = Instantiate(Resources.Load("Prefabs/InspectPrompt")) as GameObject;
        inspectPrompt.transform.position = new Vector3(transform.position.x, transform.position.y + 11, -9);
    }
	
	// Update is called once per frame
	new void Update () {
        base.Update();
	}



    public override void CheckIfPlayerIsInRange()
    {
        if (stageSpecificManager.GetComponent<MainLabManager>().ssScreenOn)
        {
            playerIsInRange = false;
            return;
        }

        if (generalManager.GetComponent<DimensionManager>().currentDimension == Dimension.DIMENSION_A)
        {
            if (mark.transform.position.x > transform.position.x - 2 && mark.transform.position.x < transform.position.x + 2)
            {
                playerIsInRange = true;
            }
            else
            {
                playerIsInRange = false;
            }
        }
        else
        {
            if (luna.transform.position.x > transform.position.x - 2 && luna.transform.position.x < transform.position.x + 2)
            {
                playerIsInRange = true;
            }
            else
            {
                playerIsInRange = false;
            }
        }
        
    }

    public override void PerformInteraction()
    {
        stageSpecificManager.GetComponent<MainLabManager>().ToggleStageSelectionScreen();

        
    }
}
