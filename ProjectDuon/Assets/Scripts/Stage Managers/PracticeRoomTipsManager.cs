using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PracticeRoomTipsManager : MonoBehaviour {

    public GameObject tipsImage;
    public GameObject generalManager;

    float finalX = 320f;
    float currX = 320f;

    float timer = 0f;
    bool timerLocked = false;

    int tip1Event = 0;
    int tip2Event = 0;
    int tip3Event = 0;
    int tip4Event = 0;
    int tip5Event = 0;
    int tip6Event = 0;
    int tip7Event = 0;

    Sprite tip1;
    Sprite tip2;
    Sprite tip3;
    Sprite tip4;
    Sprite tip5;
    Sprite tip6;
    Sprite tip7;
    Sprite tip8;
    Sprite tip9;
    Sprite tip10;
    Sprite tip11;
    Sprite tip12;


    // Use this for initialization
    void Start () {
        tipsImage = GameObject.Find("Tip");
        generalManager = GameObject.Find("GeneralManager");

        tip1 = Resources.Load<Sprite>("Graphics/UI/Tips UI/tip1");
        tip2 = Resources.Load<Sprite>("Graphics/UI/Tips UI/tip2");
        tip3 = Resources.Load<Sprite>("Graphics/UI/Tips UI/tip3");
        tip4 = Resources.Load<Sprite>("Graphics/UI/Tips UI/tip4");
        tip5 = Resources.Load<Sprite>("Graphics/UI/Tips UI/tip5");
        tip6 = Resources.Load<Sprite>("Graphics/UI/Tips UI/tip6");
        tip7 = Resources.Load<Sprite>("Graphics/UI/Tips UI/tip7");
        tip8 = Resources.Load<Sprite>("Graphics/UI/Tips UI/tip8");
        tip9 = Resources.Load<Sprite>("Graphics/UI/Tips UI/tip9");
        tip10 = Resources.Load<Sprite>("Graphics/UI/Tips UI/tip10");
        tip11 = Resources.Load<Sprite>("Graphics/UI/Tips UI/tip11");
        tip12 = Resources.Load<Sprite>("Graphics/UI/Tips UI/tip12");

        tipsImage.transform.localPosition = new Vector3(320, 0, 0);
        tipsImage.GetComponent<Image>().sprite = tip6;

        
    }

    // Update is called once per frame
    void Update() {
        if (!timerLocked)
        {
            timer += Time.deltaTime;
        }

        #region events

        //ev1
        if (timer >= 3f && tip1Event == 0)
        {
            tip1Event = 1;
            timerLocked = true;
            finalX = 0;
        }
        if (tip1Event == 1 && (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.E)))
        {

            tip1Event = 2;
            timerLocked = false;
            finalX = 320;
        }

        //ev2
        if (timer >= 13f && tip2Event == 0)
        {
            tipsImage.GetComponent<Image>().sprite = tip7;
            tip2Event = 1;
            timerLocked = true;
            finalX = 0;
        }
        if (tip2Event == 1 && generalManager.GetComponent<PauseManager>().currentState == PauseMenuState.SKILLS)
        {

            tip2Event = 2;
            timerLocked = false;
            finalX = 320;
        }

        //ev3
        if (timer >= 22f && tip3Event == 0)
        {
            timerLocked = true;
            if (!generalManager.GetComponent<PauseManager>().gameIsPaused)
            {
                tipsImage.GetComponent<Image>().sprite = tip8;
                tip3Event = 1;
                finalX = 0;
                timerLocked = false;
            }
            
        }
        if (tip3Event == 1 && timer >= 32f)
        {

            tip3Event = 2;
            timerLocked = false;
            finalX = 320;
        }

        //ev4
        if (timer >= 35f && tip4Event == 0)
        {
            tipsImage.GetComponent<Image>().sprite = tip9;
            tip4Event = 1;
            //timerLocked = true;
            finalX = 0;
        }
        if (tip4Event == 1 && timer >= 45f)
        {

            tip4Event = 2;
            //timerLocked = false;
            finalX = 320;
        }

        //ev5
        if (timer >= 55f && tip5Event == 0)
        {
            timerLocked = true;
            if (!generalManager.GetComponent<PauseManager>().gameIsPaused)
            {
                timerLocked = false;
                tipsImage.GetComponent<Image>().sprite = tip10;
                tip5Event = 1;
                finalX = 0;
            }
        }
        if (tip5Event == 1 && timer >= 65f)
        {

            tip5Event = 2;
            finalX = 320;
        }

        //ev6
        if (timer >= 70f && tip6Event == 0)
        {

            tipsImage.GetComponent<Image>().sprite = tip11;
            tip6Event = 1;
            finalX = 0;
        }
        if (tip6Event == 1 && timer >= 80f)
        {
            tip6Event = 2;
            finalX = 320;
        }

        //ev7
        if (timer >= 85f && tip7Event == 0)
        {
            timerLocked = true;
            if (!generalManager.GetComponent<PauseManager>().gameIsPaused)
            {
                tipsImage.GetComponent<Image>().sprite = tip12;
                tip7Event = 1;
                finalX = 0;
                timerLocked = false;
            }
        }
        if (tip7Event == 1 && timer >= 95f)
        {
            tip7Event = 2;
            finalX = 320;
        }


        #endregion

        currX += (finalX - currX) / 8f;

        tipsImage.transform.localPosition = new Vector3(currX, -10, 0);
    }
}
