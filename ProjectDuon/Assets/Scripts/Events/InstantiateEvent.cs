using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateEvent : GameplayEvent {

    Vector3 targetLocation;
    GameObject objToInstantiate;
    GameObject generalManager;

    public InstantiateEvent(Vector3 targetLocation, GameObject objToInstantiate)
    {
        this.targetLocation = targetLocation;
        this.objToInstantiate = objToInstantiate;
        generalManager = GameObject.Find("GeneralManager");
        requiresTimedActions = false;
    }


    public override IEnumerator ExecuteEvent()
    {
        GameObject.Instantiate(objToInstantiate, targetLocation, Quaternion.identity);
        isFinished = true;
        return null;
    }

    
}
