using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitEvent : GameplayEvent
{
    float waitDuration;

    public WaitEvent(float waitDuration)
    {
        this.waitDuration = waitDuration;
        requiresTimedActions = true;
    }

    public override IEnumerator ExecuteEvent()
    {
        yield return new WaitForSeconds(waitDuration);
        isFinished = true;
    }
}
