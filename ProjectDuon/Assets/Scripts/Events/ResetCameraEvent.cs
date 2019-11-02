using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCameraEvent : GameplayEvent
{
    GameObject generalCamera;

    public ResetCameraEvent()
    {
        generalCamera = GameObject.Find("GeneralCamera");
        requiresTimedActions = false;
    }

    public override IEnumerator ExecuteEvent()
    {
        generalCamera.GetComponent<CameraController>().isFollowingPlayer = true;
        isFinished = true;
        return null;
    }
}
