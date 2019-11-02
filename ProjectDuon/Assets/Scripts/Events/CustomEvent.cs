using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class CustomEvent : GameplayEvent
{
    /* syntax for custom events:
     * 
       generalManager.GetComponent<EventIssuer>().IssueCustomEvent(typeof(Type in which the event function is declared in).GetMethod("method name"), this);
        remenber to make the method public
     * 
     * */

    MethodInfo action;
    object sender;
    Type senderType;

    public CustomEvent(MethodInfo action, object sender)
    {
        this.action = action;
        this.sender = sender;
        requiresTimedActions = false;
    }


    public override IEnumerator ExecuteEvent()
    {
        action.Invoke(sender, null);
        isFinished = true;
        return null;
    }
}
