using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1PreBossManager : MonoBehaviour {

    GameObject generalManager;
    GameObject document;
    GameObject tail;
    GameObject mark;
    GameObject luna;

    public Sprite docSprite1;
    public Sprite docSprite2;

    // Use this for initialization
    void Start () {
        


        generalManager = GameObject.Find("GeneralManager");
        tail = GameObject.Find("Hollow Alpha Tail");

        mark = GameObject.Find("Mark");
        luna = GameObject.Find("Luna");

        document = GameObject.Find("Documents");

        mark.GetComponent<Mark>().isFacingRight = false;
        luna.GetComponent<Luna>().isFacingRight = false;

        if (GlobalHolder.stage1Checkpoint)
        {
            mark.transform.position = new Vector3(70, mark.transform.position.y, mark.transform.position.z);
            luna.transform.position = new Vector3(70, luna.transform.position.y, luna.transform.position.z);
        }
        else if (!GlobalHolder.stage1Complete)
        {
            generalManager.GetComponent<DimensionManager>().currentDimension = Dimension.DIMENSION_Z;
            CurrentDimensionHolder.currentDimension = Dimension.DIMENSION_Z;
            document.GetComponent<SpriteRenderer>().sprite = docSprite1;
            generalManager.GetComponent<EventIssuer>().Wait(1f);
            generalManager.GetComponent<EventIssuer>().IssueDialogueEvent("Dia Stage 1 PreBoss");
            generalManager.GetComponent<EventIssuer>().ChangeCameraTarget(document);
            generalManager.GetComponent<EventIssuer>().Wait(1f);
            generalManager.GetComponent<EventIssuer>().PlaySound(Resources.Load("Sound/SFX/Misc/Paper1") as AudioClip, 0.5f);
            generalManager.GetComponent<EventIssuer>().IssueCustomEvent(typeof(Stage1PreBossManager).GetMethod("ChangeSprite"), this);
            generalManager.GetComponent<EventIssuer>().Wait(0.5f);
            generalManager.GetComponent<EventIssuer>().IssueDialogueEvent("Dia Stage 1 PreBoss 2");
            generalManager.GetComponent<EventIssuer>().ChangeCameraTarget(tail);
            generalManager.GetComponent<EventIssuer>().PlaySound(Resources.Load("Sound/SFX/Misc/hollow alpha buildup") as AudioClip, 0.3f);
            generalManager.GetComponent<EventIssuer>().Wait(4f);
            generalManager.GetComponent<EventIssuer>().ResetCameraTarget();
            generalManager.GetComponent<EventIssuer>().IssueDialogueEvent("Dia Stage 1 PreBoss 3");
        }
        
        


    }
	

	// Update is called once per frame
	void Update () {
        
	}
    
    public void ChangeSprite()
    {
        document.GetComponent<SpriteRenderer>().sprite = docSprite2;
    }
}
