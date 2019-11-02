using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : Interactable {

    Animator animator;
    GameObject doorA;
    GameObject elevatorZ;
    bool triggered = false;

    // Use this for initialization
    new void Start () {
        base.Start();
        animator = GetComponent<Animator>();

        inspectPrompt = Instantiate(Resources.Load("Prefabs/InspectPrompt")) as GameObject;
        inspectPrompt.transform.position = new Vector3(transform.position.x + 17.75f, transform.position.y - 18.5f, -9);

        doorA = transform.Find("Door A").gameObject;
        elevatorZ = transform.Find("Elevator Z").gameObject;

    }
	
	// Update is called once per frame
	new void Update () {
        base.Update();

        if (!triggered)
        {
            if (generalManager.GetComponent<DimensionManager>().currentDimension == Dimension.DIMENSION_Z)
            {
                if (elevatorZ.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Open"))
                {
                    generalManager.GetComponent<SceneTransitioner>().TransitionWithFade("Stage1Boss", Color.black);
                    triggered = true;
                }
            }
            else
            {
                if (doorA.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Open"))
                {
                    generalManager.GetComponent<SceneTransitioner>().TransitionWithFade("Stage1Boss", Color.black);
                    triggered = true;
                }
            }
        }

        
	}

    public override void CheckIfPlayerIsInRange()
    {
        if (generalManager.GetComponent<DimensionManager>().currentDimension == Dimension.DIMENSION_Z)
        {
            if (luna.transform.position.x <= -45f)
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
            if (mark.transform.position.x <= -45f)
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
        if (generalManager.GetComponent<DimensionManager>().currentDimension == Dimension.DIMENSION_Z)
        {
            elevatorZ.GetComponent<Animator>().SetTrigger("Open");
        }
        else
        {
            doorA.GetComponent<Animator>().SetTrigger("Open");
        }

        generalManager.GetComponent<EventIssuer>().Wait(10f);

    }

    

    
}
