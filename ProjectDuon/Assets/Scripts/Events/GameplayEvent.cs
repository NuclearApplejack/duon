using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameplayEvent {

    public bool requiresTimedActions;
    public bool isFinished = false;

    public abstract IEnumerator ExecuteEvent();


}
