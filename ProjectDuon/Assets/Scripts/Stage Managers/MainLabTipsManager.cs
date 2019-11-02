using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainLabTipsManager : MonoBehaviour {

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

    Sprite tip1;
    Sprite tip2;
    Sprite tip3;
    Sprite tip4;
    Sprite tip5;
    Sprite tip6;
    Sprite tip7;
    Sprite tip8;
    Sprite tip9;


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

        tipsImage.transform.localPosition = new Vector3(320, 0, 0);
        tipsImage.GetComponent<Image>().sprite = tip1;

        
    }
	
	// Update is called once per frame
	void Update () {
        if (!timerLocked)
        {
            timer += Time.deltaTime;
        }

        #region events
        if (!GlobalHolder.mainLabTipsSeen)
        {
            //ev1
            if (timer >= 3f && tip1Event == 0)
            {
                tip1Event = 1;
                timerLocked = true;
                finalX = 0;
            }
            if (tip1Event == 1 && (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)))
            {

                tip1Event = 2;
                timerLocked = false;
                finalX = 320;
            }

            //ev2
            if (timer >= 7f && tip2Event == 0)
            {
                tipsImage.GetComponent<Image>().sprite = tip2;
                tip2Event = 1;
                timerLocked = true;
                finalX = 0;
            }
            if (tip2Event == 1 && Input.GetKey(KeyCode.Space))
            {

                tip2Event = 2;
                timerLocked = false;
                finalX = 320;
            }

            //ev3
            if (timer >= 11f && tip3Event == 0)
            {
                tipsImage.GetComponent<Image>().sprite = tip3;
                tip3Event = 1;
                timerLocked = true;
                finalX = 0;
            }
            if (tip3Event == 1 && generalManager.GetComponent<DialogueManager>().dialogueSequenceIsOn)
            {

                tip3Event = 2;
                timerLocked = false;
                finalX = 320;
            }

            //ev4
            if (timer >= 21f && tip4Event == 0)
            {
                timerLocked = true;
                if (!generalManager.GetComponent<DialogueManager>().dialogueSequenceIsOn)
                {
                    tipsImage.GetComponent<Image>().sprite = tip4;
                    tip4Event = 1;
                    finalX = 0;
                }
            }
            if (tip4Event == 1 && Input.GetKey(KeyCode.LeftShift))
            {

                tip4Event = 2;
                timerLocked = false;
                finalX = 320;
            }

            //ev5
            if (timer >= 28f && tip5Event == 0)
            {
                timerLocked = true;
                if (!generalManager.GetComponent<DialogueManager>().dialogueSequenceIsOn)
                {
                    tipsImage.GetComponent<Image>().sprite = tip5;
                    tip5Event = 1;
                    finalX = 0;
                    timerLocked = false;
                }
            }
            if (tip5Event == 1 && timer >= 38f)
            {
                GlobalHolder.mainLabTipsSeen = true;
                tip5Event = 2;
                finalX = 320;
            }
        }
        #endregion

        currX += (finalX - currX) / 8f;

        tipsImage.transform.localPosition = new Vector3(currX, -10, 0);
    }
}
