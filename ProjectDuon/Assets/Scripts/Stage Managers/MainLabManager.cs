using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class MainLabManager : MonoBehaviour {

    GameObject generalManager;
    public GameObject stageSelectionUI;

    public GameObject stageSelectionBGS;
    public GameObject stageSelectionHLS;
    public GameObject leftArrow;
    public GameObject rightArrow;

    public GameObject songPlayerA;
    public GameObject songPlayerZ;

    float songWeight = 0f;


    public float finalSSPosX = 320f;
    public float currSSPosX = 320f;
    public int currSSStage = 0;
    int totalStages = 2;

    public bool ssScreenOn = false;

    GameObject omk1;

    MethodInfo methodInfo;

    // Use this for initialization
    void Start () {
        generalManager = GameObject.Find("GeneralManager");
        stageSelectionUI = GameObject.Find("StageSelectionUI");
        stageSelectionBGS = GameObject.Find("StageBG");
        stageSelectionHLS = GameObject.Find("StageHighlights");
        leftArrow = GameObject.Find("LeftArrow");
        rightArrow = GameObject.Find("RightArrow");
        songPlayerA = GameObject.Find("SongPlayerA");
        songPlayerZ = GameObject.Find("SongPlayerZ");



        stageSelectionUI.SetActive(false);



        omk1 = GameObject.Find("OMK 1");

        if (!GlobalHolder.stage1Complete)
        {
            omk1.SetActive(false);
        }
        if (generalManager.GetComponent<DimensionManager>().currentDimension == Dimension.DIMENSION_Z)
        {
            songWeight = 1f;
        }

    }
	

	// Update is called once per frame
	void Update () {

        if (generalManager.GetComponent<DimensionManager>().currentDimension == Dimension.DIMENSION_A)
        {
            /*
            songPlayerA.GetComponent<AudioSource>().volume = 1f;
            songPlayerZ.GetComponent<AudioSource>().volume = 0f;*/
            if (songWeight > 0f)
            {
                songWeight -= Time.deltaTime / 2f;
                if (songWeight < 0f)
                {
                    songWeight = 0f;
                }
            }
            
        }
        else
        {
            /*
            songPlayerA.GetComponent<AudioSource>().volume = 0f;
            songPlayerZ.GetComponent<AudioSource>().volume = 1f;*/
            if (songWeight < 1f)
            {
                songWeight += Time.deltaTime / 2f;
                if (songWeight > 1f)
                {
                    songWeight = 1f;
                }
            }
        }
        songPlayerA.GetComponent<AudioSource>().volume = 1f - songWeight;
        songPlayerZ.GetComponent<AudioSource>().volume = songWeight;


        if (ssScreenOn)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ToggleStageSelectionScreen();
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                currSSStage = Mathf.Max(0, currSSStage - 1);
                finalSSPosX = 320f - (640f * currSSStage);

            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {

                currSSStage = Mathf.Min(totalStages - 1, currSSStage + 1);
                finalSSPosX = 320f - (640f * currSSStage);
            

            }
            else if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
            {
                if (currSSStage == 0)
                {
                    generalManager.GetComponent<SceneTransitioner>().TransitionWithFade("PracticeRoom", Color.black);
                }
                else
                {
                    generalManager.GetComponent<SceneTransitioner>().TransitionWithFade("Stage1PreBoss", Color.black);
                }
            }
        }

        currSSPosX += (finalSSPosX - currSSPosX) / 4f;
        stageSelectionBGS.transform.localPosition = new Vector3(currSSPosX, stageSelectionBGS.transform.localPosition.y, 0);
        stageSelectionHLS.transform.localPosition = new Vector3(currSSPosX, stageSelectionHLS.transform.localPosition.y, 0);

        if (currSSStage == 0)
        {
            leftArrow.GetComponent<Image>().color = new Color(1, 1, 1, 0f);
        }
        else
        {
            leftArrow.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }

        if (currSSStage == totalStages - 1)
        {
            rightArrow.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphics/UI/Stage Selection Menu/stage selection arrow txt");
            rightArrow.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
        }
        else
        {
            rightArrow.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphics/UI/Stage Selection Menu/stage selection arrow");
            rightArrow.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }

    }

    public void ToggleStageSelectionScreen()
    {
        ssScreenOn = !ssScreenOn;

        if (ssScreenOn)
        {
            stageSelectionUI.SetActive(true);
            generalManager.GetComponent<PauseManager>().manualPaused = true;


        }
        else
        {
            stageSelectionUI.SetActive(false);
            generalManager.GetComponent<PauseManager>().manualPaused = false;
        }
    }

    
}
