using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimatorEvent : GameplayEvent
{
    Animator animator;
    string triggerName;

    public TriggerAnimatorEvent(Animator animator, string triggerName)
    {
        this.animator = animator;
        this.triggerName = triggerName;

        requiresTimedActions = false;
    }

    public override IEnumerator ExecuteEvent()
    {
        animator.SetTrigger(triggerName);
        isFinished = true;
        return null;
    }
}
