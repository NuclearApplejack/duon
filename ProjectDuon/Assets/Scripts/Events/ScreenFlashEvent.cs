using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFlashEvent : GameplayEvent
{
    GameObject screenEffect;

    Color color;
    float timeUp;
    float timeDown;
    float wait;

    bool instant;

    public ScreenFlashEvent(Color color, float timeUp, float timeDown, float wait, bool instant)
    {
        this.color = color;
        this.timeUp = timeUp;
        this.timeDown = timeDown;
        this.wait = wait;

        this.instant = instant;

        requiresTimedActions = true;

        screenEffect = GameObject.Find("ScreenEffect");
    }

    public override IEnumerator ExecuteEvent()
    {
        if (instant)
        {
            isFinished = true;
        }

        float alpha = 0;
        while (alpha < color.a)
        {
            alpha += Time.deltaTime / timeUp;
            alpha = Mathf.Min(color.a, alpha);
            screenEffect.GetComponent<Image>().color = new Color(color.r, color.g, color.b, color.a * alpha);
            yield return null;
        }

        yield return new WaitForSeconds(wait);

        while (alpha > 0)
        {
            alpha -= Time.deltaTime / timeDown;
            alpha = Mathf.Max(0, alpha);
            screenEffect.GetComponent<Image>().color = new Color(color.r, color.g, color.b, color.a * alpha);
            yield return null;
        }

        isFinished = true;

    }
}
