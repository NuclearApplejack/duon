using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTargetEvent : GameplayEvent {

    GameObject newTarget;
    GameObject generalCamera;


    public CameraTargetEvent(GameObject newTarget)
    {
        this.newTarget = newTarget;
        generalCamera = GameObject.Find("GeneralCamera");
        requiresTimedActions = false;
    }

    public override IEnumerator ExecuteEvent()
    {
        generalCamera.GetComponent<CameraController>().isFollowingPlayer = false;
        generalCamera.GetComponent<CameraController>().target = newTarget;
        isFinished = true;
        return null;
    }

   
}
