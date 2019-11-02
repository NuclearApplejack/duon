using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HollowAlphaStageManager : MonoBehaviour {

    GameObject hollowAlpha;

    GameObject shieldBar;
    GameObject healthBar;

    GameObject generalManager;
    GameObject omk;
    GameObject bossUI;
    
    public Sprite healthBarNormal;
    public Sprite healthBarVulnerable;

    bool endTriggered = false;


    bool startSeqHasStarted = false;
    bool startSequenceIsOver = false;

    bool initialSeqFinished = false;

    public AudioClip shriek;
    public AudioClip death;

    // Use this for initialization
    void Start () {
        
        hollowAlpha = GameObject.Find("HollowAlpha");
        omk = GameObject.Find("OMK");
        omk.SetActive(false);
        generalManager = GameObject.Find("GeneralManager");

        healthBar = GameObject.Find("HollowAlphaHealth");
        shieldBar = GameObject.Find("HollowAlphaShield");

        bossUI = GameObject.Find("StageUI");



        InitiateStage();
        


        
    }
	
    void InitiateStage()
    {

        if (GlobalHolder.hollowAlphaSeen)
        {
            GetComponent<BGMPlayer>().PlayBGM();
            generalManager.GetComponent<EventIssuer>().SetAnimatorTrigger(hollowAlpha.GetComponent<Animator>(), "Wake");
            startSequenceIsOver = true;
            hollowAlpha.GetComponent<HollowAlpha>().state = HollowAlphaState.IDLE;
        }
        else
        {
            
            

            bossUI.SetActive(false);
            GameObject effect = Resources.Load("Prefabs/ScreamEffect") as GameObject;


            generalManager.GetComponent<EventIssuer>().forcedEventIsOn = true;

            startSequenceIsOver = false;


            #region startup events

            //yield return new WaitForSeconds(1f);

            
            
            startSeqHasStarted = true;
            GetComponent<BGMPlayer>().PlayBGM();


            generalManager.GetComponent<EventIssuer>().Wait(1f);

            

            generalManager.GetComponent<EventIssuer>().ChangeCameraTarget(hollowAlpha);

            generalManager.GetComponent<EventIssuer>().Wait(2.45f);
            generalManager.GetComponent<EventIssuer>().ShakeScreen(true, 0.2f, 0.2f);
            generalManager.GetComponent<EventIssuer>().FlashScreen(0f, 0.5f, 0f, new Color(1, 1, 1, 0.2f), true);
            generalManager.GetComponent<EventIssuer>().Wait(1.65f);
            generalManager.GetComponent<EventIssuer>().ShakeScreen(true, 0.4f, 0.2f);
            generalManager.GetComponent<EventIssuer>().SetAnimatorTrigger(hollowAlpha.GetComponent<Animator>(), "Wake2");
            generalManager.GetComponent<EventIssuer>().FlashScreen(0f, 0.5f, 0f, new Color(1, 1, 1, 0.3f), true);
            generalManager.GetComponent<EventIssuer>().Wait(1.65f);
            generalManager.GetComponent<EventIssuer>().ShakeScreen(true, 0.5f, 0.2f);
            generalManager.GetComponent<EventIssuer>().SetAnimatorTrigger(hollowAlpha.GetComponent<Animator>(), "Wake3");
            generalManager.GetComponent<EventIssuer>().FlashScreen(0f, 0.5f, 0f, new Color(1, 1, 1, 0.4f), true);
            generalManager.GetComponent<EventIssuer>().Wait(4.95f);

            generalManager.GetComponent<EventIssuer>().PlaySound(shriek, 0.6f);
            generalManager.GetComponent<EventIssuer>().Wait(0.5f);
            generalManager.GetComponent<EventIssuer>().FlashScreen(0f, 0.5f, 0f, Color.white, true);
            generalManager.GetComponent<EventIssuer>().SetAnimatorTrigger(hollowAlpha.GetComponent<Animator>(), "Wake4");
            generalManager.GetComponent<EventIssuer>().ShakeScreen(true, 1f, 1f);




            generalManager.GetComponent<EventIssuer>().InstantiateObject(effect, new Vector3(hollowAlpha.transform.position.x, hollowAlpha.transform.position.y, hollowAlpha.transform.position.z - 0.1f));
            generalManager.GetComponent<EventIssuer>().Wait(0.05f);
            generalManager.GetComponent<EventIssuer>().InstantiateObject(effect, new Vector3(hollowAlpha.transform.position.x, hollowAlpha.transform.position.y, hollowAlpha.transform.position.z - 0.1f));
            generalManager.GetComponent<EventIssuer>().Wait(0.05f);
            generalManager.GetComponent<EventIssuer>().InstantiateObject(effect, new Vector3(hollowAlpha.transform.position.x, hollowAlpha.transform.position.y, hollowAlpha.transform.position.z - 0.1f));
            generalManager.GetComponent<EventIssuer>().Wait(0.05f);
            generalManager.GetComponent<EventIssuer>().InstantiateObject(effect, new Vector3(hollowAlpha.transform.position.x, hollowAlpha.transform.position.y, hollowAlpha.transform.position.z - 0.1f));
            generalManager.GetComponent<EventIssuer>().Wait(0.05f);
            generalManager.GetComponent<EventIssuer>().InstantiateObject(effect, new Vector3(hollowAlpha.transform.position.x, hollowAlpha.transform.position.y, hollowAlpha.transform.position.z - 0.1f));
            generalManager.GetComponent<EventIssuer>().Wait(0.05f);
            generalManager.GetComponent<EventIssuer>().InstantiateObject(effect, new Vector3(hollowAlpha.transform.position.x, hollowAlpha.transform.position.y, hollowAlpha.transform.position.z - 0.1f));
            generalManager.GetComponent<EventIssuer>().Wait(0.05f);
            generalManager.GetComponent<EventIssuer>().InstantiateObject(effect, new Vector3(hollowAlpha.transform.position.x, hollowAlpha.transform.position.y, hollowAlpha.transform.position.z - 0.1f));
            generalManager.GetComponent<EventIssuer>().Wait(0.05f);
            generalManager.GetComponent<EventIssuer>().InstantiateObject(effect, new Vector3(hollowAlpha.transform.position.x, hollowAlpha.transform.position.y, hollowAlpha.transform.position.z - 0.1f));
            generalManager.GetComponent<EventIssuer>().Wait(0.05f);
            generalManager.GetComponent<EventIssuer>().InstantiateObject(effect, new Vector3(hollowAlpha.transform.position.x, hollowAlpha.transform.position.y, hollowAlpha.transform.position.z - 0.1f));
            generalManager.GetComponent<EventIssuer>().Wait(0.05f);
            generalManager.GetComponent<EventIssuer>().InstantiateObject(effect, new Vector3(hollowAlpha.transform.position.x, hollowAlpha.transform.position.y, hollowAlpha.transform.position.z - 0.1f));
            generalManager.GetComponent<EventIssuer>().Wait(0.05f);
            generalManager.GetComponent<EventIssuer>().InstantiateObject(effect, new Vector3(hollowAlpha.transform.position.x, hollowAlpha.transform.position.y, hollowAlpha.transform.position.z - 0.1f));
            generalManager.GetComponent<EventIssuer>().Wait(0.05f);
            generalManager.GetComponent<EventIssuer>().InstantiateObject(effect, new Vector3(hollowAlpha.transform.position.x, hollowAlpha.transform.position.y, hollowAlpha.transform.position.z - 0.1f));
            generalManager.GetComponent<EventIssuer>().Wait(0.05f);
            generalManager.GetComponent<EventIssuer>().InstantiateObject(effect, new Vector3(hollowAlpha.transform.position.x, hollowAlpha.transform.position.y, hollowAlpha.transform.position.z - 0.1f));
            generalManager.GetComponent<EventIssuer>().Wait(0.05f);
            generalManager.GetComponent<EventIssuer>().InstantiateObject(effect, new Vector3(hollowAlpha.transform.position.x, hollowAlpha.transform.position.y, hollowAlpha.transform.position.z - 0.1f));
            generalManager.GetComponent<EventIssuer>().Wait(0.05f);
            generalManager.GetComponent<EventIssuer>().InstantiateObject(effect, new Vector3(hollowAlpha.transform.position.x, hollowAlpha.transform.position.y, hollowAlpha.transform.position.z - 0.1f));
            generalManager.GetComponent<EventIssuer>().Wait(0.05f);
            generalManager.GetComponent<EventIssuer>().InstantiateObject(effect, new Vector3(hollowAlpha.transform.position.x, hollowAlpha.transform.position.y, hollowAlpha.transform.position.z - 0.1f));
            generalManager.GetComponent<EventIssuer>().Wait(0.1f);


            generalManager.GetComponent<EventIssuer>().ResetCameraTarget();
            
            #endregion

            generalManager.GetComponent<EventIssuer>().forcedEventIsOn = false;
        }

        
    }



    // Update is called once per frame
    void Update () {
        

        

        if (startSeqHasStarted && !startSequenceIsOver)
        {
            if (!generalManager.GetComponent<EventIssuer>().EventsAreOn())
            {
                startSequenceIsOver = true;
                GlobalHolder.hollowAlphaSeen = true;
                hollowAlpha.GetComponent<HollowAlpha>().state = HollowAlphaState.IDLE;      
                bossUI.SetActive(true);
            }
        }

        if (hollowAlpha.GetComponent<HollowAlpha>().currentHealth <= 0 && !endTriggered)
        {
            endTriggered = true;
            GlobalHolder.stage1Checkpoint = false;
            GetComponent<BGMPlayer>().PauseBGM();
            generalManager.GetComponent<EventIssuer>().FlashScreen(0f, 0.5f, 0f, Color.white, true);
            bossUI.SetActive(false);
            GlobalHolder.stage1Complete = true;
            omk.SetActive(true);
            GetComponent<AudioSource>().Play();
            GetComponent<AudioSource>().loop = true;
            generalManager.GetComponent<EventIssuer>().PlaySound(death, 0.6f);
            generalManager.GetComponent<EventIssuer>().ShakeScreen(false, 1f, 0.5f);
            generalManager.GetComponent<EventIssuer>().Wait(1f);
            generalManager.GetComponent<EventIssuer>().IssueDialogueEvent("Dia Stage 1 End 1");
            generalManager.GetComponent<EventIssuer>().ChangeCameraTarget(omk);
            generalManager.GetComponent<EventIssuer>().Wait(3f);
            generalManager.GetComponent<EventIssuer>().IssueDialogueEvent("Dia Stage 1 End 2");
            generalManager.GetComponent<EventIssuer>().TransitionWithFade("DemoEnd", Color.black);


        }
        
    }

    void OnGUI()
    {
        if (!generalManager.GetComponent<DialogueManager>().dialogueSequenceIsOn)
        {

            //shield
            shieldBar.GetComponent<RectTransform>().localScale = new Vector3(Mathf.RoundToInt(((float)hollowAlpha.GetComponent<HollowAlpha>().currentShield / hollowAlpha.GetComponent<HollowAlpha>().maxShield) * 500) / 500f, 1, 1);

            //health
            healthBar.GetComponent<RectTransform>().localScale = new Vector3(Mathf.RoundToInt(((float)hollowAlpha.GetComponent<HollowAlpha>().currentHealth / hollowAlpha.GetComponent<HollowAlpha>().maxHealth) * 500) / 500f, 1, 1);

            if (hollowAlpha.GetComponent<HollowAlpha>().currentShield <= 0)
            {
                healthBar.GetComponent<Image>().sprite = healthBarVulnerable;
            }
            else
            {
                healthBar.GetComponent<Image>().sprite = healthBarNormal;
            }
        }
    }
}
