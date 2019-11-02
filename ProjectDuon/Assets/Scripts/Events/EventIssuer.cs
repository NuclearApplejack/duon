using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class EventIssuer : MonoBehaviour {
    
    bool eventIsOn = false;
    public bool eventSequenceIsOn = false;
    public bool forcedEventIsOn = false;

    public Queue<GameplayEvent> eventQueue = new Queue<GameplayEvent>();
    

    GameObject generalManager;
    GameObject generalCamera;
    GameObject screenEffect;

    

    // Use this for initialization
    void Start () {
        generalManager = GameObject.Find("GeneralManager");
        generalCamera = GameObject.Find("GeneralCamera");
        screenEffect = GameObject.Find("ScreenEffect");
    }
	
	// Update is called once per frame
	void Update () {
        CheckIfEventsAreOn();

        if (eventQueue.Count > 0)
        {
            if (!eventIsOn)
            {
                eventIsOn = true;
                if (eventQueue.Peek().requiresTimedActions)
                {
                    StartCoroutine(eventQueue.Peek().ExecuteEvent());
                }
                else
                {
                    eventQueue.Peek().ExecuteEvent();
                }

            }

            if (eventQueue.Peek().GetType() == typeof(DialogueEvent) && !generalManager.GetComponent<DialogueManager>().dialogueSequenceIsOn)
            {
                eventIsOn = false;
                eventQueue.Dequeue();
            }
            else if (eventQueue.Peek().isFinished)
            {
                eventIsOn = false;
                eventQueue.Dequeue();
            }

            
        }
    }

    void CheckIfEventsAreOn()
    {
        
        if (eventQueue.Count > 0)
        {
            eventSequenceIsOn = true;
            return;
        }

        if (generalManager.GetComponent<DialogueManager>().dialogueSequenceIsOn)
        {
            eventSequenceIsOn = true;
            return;
        }
        
        eventSequenceIsOn = false;
    }

    public bool EventsAreOn()
    {
        return eventSequenceIsOn || forcedEventIsOn;
    }

    #region event issuing methods

    public void IssueDialogueEvent(string fileName)
    {
        DialogueEvent dEvent = new DialogueEvent(fileName);
        eventQueue.Enqueue(dEvent);
    }

    public void ChangeCameraTarget(GameObject newTarget)
    {

        CameraTargetEvent cEvent = new CameraTargetEvent(newTarget);
        eventQueue.Enqueue(cEvent);
    }

    public void ResetCameraTarget()
    {
        ResetCameraEvent rEvent = new ResetCameraEvent();
        eventQueue.Enqueue(rEvent);
    }

    public void ShakeScreen(bool instant, float factor = 1f, float time = 1f)
    {
        ScreenShakeEvent ssEvent = new ScreenShakeEvent(instant, factor, time);
        eventQueue.Enqueue(ssEvent);
    }

    public IEnumerator ShakeScreenDuringGameplay(float factor = 1f, float duration = 1f)
    {
        float shakeTimer = 0f;
        float shakeFactor = 0f;
        float currentCameraAngle = 0f;

        shakeTimer = duration;
        shakeFactor = factor;

        while (shakeTimer > 0)
        {
            shakeTimer = shakeTimer - Time.deltaTime;

            float randomAngle = Random.Range(0f, 180f);
            currentCameraAngle += randomAngle + 90f;

            float movX = 0f;
            float movY = 0f;

            movX = Mathf.Cos(Mathf.Deg2Rad * currentCameraAngle) * shakeFactor;
            movY = Mathf.Sin(Mathf.Deg2Rad * currentCameraAngle) * shakeFactor;


            generalCamera.transform.position = new Vector3(generalCamera.transform.position.x + movX, generalCamera.transform.position.y + movY, generalCamera.transform.position.z);
            
            yield return new WaitForSeconds(0.02f);
        }
    }

    public void Wait(float waitDuration)
    {
        WaitEvent wEvent = new WaitEvent(waitDuration);
        eventQueue.Enqueue(wEvent);
    }

    public void PlaySound(AudioClip soundEffect, float volume)
    {
        SoundEvent sEvent = new SoundEvent(soundEffect, GetComponent<AudioSource>(), volume);
        eventQueue.Enqueue(sEvent);
    }

    public void TransitionWithFade(string sceneName, Color color)
    {
        SceneTransitionFadeEvent fEvent = new SceneTransitionFadeEvent(sceneName, color);
        eventQueue.Enqueue(fEvent);
    }

    public void InstantiateObject(GameObject newObj, Vector3 position)
    {
        InstantiateEvent iEvent = new InstantiateEvent(position, newObj);
        eventQueue.Enqueue(iEvent);
    }

    public IEnumerator FlashScreenDuringGameplay(float timeUp, float timeDown, float wait, Color color)
    {
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


    }

    public void FlashScreen(float timeUp, float timeDown, float wait, Color color, bool instant)
    {
        ScreenFlashEvent fEvent = new ScreenFlashEvent(color, timeUp, timeDown, wait, instant);
        eventQueue.Enqueue(fEvent);
    }

    public void SetAnimatorTrigger(Animator animator, string triggerName)
    {
        TriggerAnimatorEvent tEvent = new TriggerAnimatorEvent(animator, triggerName);
        eventQueue.Enqueue(tEvent);
    }

    public void IssueCustomEvent(MethodInfo action, object sender)
    {
        CustomEvent cEvent = new CustomEvent(action, sender);
        eventQueue.Enqueue(cEvent);
    }

    #endregion
}
