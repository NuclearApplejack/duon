using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShakeEvent : GameplayEvent{
    float factor;
    float duration;

    bool instant;

    GameObject generalCamera;

    public ScreenShakeEvent(bool instant, float factor = 1f, float duration = 1f)
    {
        this.factor = factor;
        this.duration = duration;
        this.instant = instant;

        generalCamera = GameObject.Find("GeneralCamera");
        requiresTimedActions = true;
    }

    public override IEnumerator ExecuteEvent()
    {
        if (instant)
        {
            isFinished = true;
        }

        float shakeTimer = 0f;
        float shakeFactor = 0f;
        float currentCameraAngle = 0f;

        shakeTimer = duration;
        shakeFactor = factor;

        while (shakeTimer > 0)
        {
            shakeTimer = shakeTimer - Time.deltaTime;

            float randomAngle = UnityEngine.Random.Range(0f, 180f);
            currentCameraAngle += randomAngle + 90f;

            float movX = 0f;
            float movY = 0f;

            movX = Mathf.Cos(Mathf.Deg2Rad * currentCameraAngle) * shakeFactor;
            movY = Mathf.Sin(Mathf.Deg2Rad * currentCameraAngle) * shakeFactor;


            generalCamera.transform.position = new Vector3(generalCamera.transform.position.x + movX, generalCamera.transform.position.y + movY, generalCamera.transform.position.z);
            yield return new WaitForSeconds(0.02f);
        }
        isFinished = true;

    }
}
