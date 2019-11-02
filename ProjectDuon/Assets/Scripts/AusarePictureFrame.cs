using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AusarePictureFrame : Interactable {

    public Sprite ausareFrame;

    new void Start()
    {
        base.Start();

        //GlobalHolder.stage1Complete = true;

        inspectPrompt = Instantiate(Resources.Load("Prefabs/InspectPrompt")) as GameObject;
        inspectPrompt.transform.position = new Vector3(transform.position.x, transform.position.y + 3, -9);

        if (GlobalHolder.stage1Complete)
        {
            GetComponent<SpriteRenderer>().sprite = ausareFrame;
        }
    }

    new void Update() 
    {
        base.Update();
    }

    public override void CheckIfPlayerIsInRange()
    {
        if (generalManager.GetComponent<DimensionManager>().currentDimension != Dimension.DIMENSION_Z)
        {
            playerIsInRange = false;
            return;
        }

        if (!GlobalHolder.stage1Complete)
        {
            playerIsInRange = false;
            return;
        }

        if (luna.transform.position.x > transform.position.x - 2 && luna.transform.position.x < transform.position.x + 2)
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

        generalManager.GetComponent<DialogueManager>().QueueDialogueFile("Dia Main Lab Picture Z");

    }

}
