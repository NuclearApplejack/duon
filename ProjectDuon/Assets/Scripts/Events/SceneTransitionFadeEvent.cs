using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransitionFadeEvent : GameplayEvent
{
    SceneTransitioner transitioner;

    string sceneName;
    Color color;

    public SceneTransitionFadeEvent(string sceneName, Color color)
    {
        this.sceneName = sceneName;
        this.color = color;
        requiresTimedActions = false;

        transitioner = GameObject.Find("GeneralManager").GetComponent<SceneTransitioner>();
    }

    public override IEnumerator ExecuteEvent()
    {
        transitioner.TransitionWithFade(sceneName, color);
        return null;
    }
}
