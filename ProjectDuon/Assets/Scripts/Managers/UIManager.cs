using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    Mark mark;
    Luna luna;

    GameObject[] nonDialogueUI;
    GameObject dialogueUIObject;
    GameObject markStats;
    GameObject lunaStats;
    GameObject uiPanel;
    GameObject dialoguePanel;

    GameObject markHealth;
    GameObject markStamina;
    GameObject lunaHealth;
    GameObject lunaStamina;
    GameObject switcherLight;


    public Sprite markHUD;
    public Sprite lunaHUD;
    public Sprite markHUDon;
    public Sprite lunaHUDon;


    float xScalar;
    float yScalar;

    public Sprite switcherOff;
    public List<Sprite> switcherOnStates = new List<Sprite>();
    int switcherState = -1;
    [HideInInspector]
    public float switchFlashTimer = 0f;

    public Sprite staminaBarNormal;
    public Sprite staminaBarExhausted;

    

    // Use this for initialization
    void Start () {
        mark = GameObject.Find("Mark").GetComponent<Mark>();
        luna = GameObject.Find("Luna").GetComponent<Luna>();

        /*
        switcherOff = Resources.Load("Graphics/UI/Main UI/switcher light off") as Sprite;
        switcherOnStates.Add(Resources.Load("Graphics/UI/Main UI/switcher light1") as Sprite);
        switcherOnStates.Add(Resources.Load("Graphics/UI/Main UI/switcher light2") as Sprite);
        switcherOnStates.Add(Resources.Load("Graphics/UI/Main UI/switcher light3") as Sprite);
        switcherOnStates.Add(Resources.Load("Graphics/UI/Main UI/switcher light4") as Sprite);
        switcherOnStates.Add(Resources.Load("Graphics/UI/Main UI/switcher light5") as Sprite);
        switcherOnStates.Add(Resources.Load("Graphics/UI/Main UI/switcher light6") as Sprite);
        switcherOnStates.Add(Resources.Load("Graphics/UI/Main UI/switcher light7") as Sprite);*/

        //staminaBarNormal = Resources.Load("Graphics/UI/Main UI/stamina bar") as Sprite;
        //staminaBarExhausted = Resources.Load("Graphics/UI/Main UI/stamina bar exhausted") as Sprite;

        nonDialogueUI = GameObject.FindGameObjectsWithTag("Non-dialogue UI");
        dialogueUIObject = GameObject.Find("DialogueUI");
        markStats = GameObject.Find("MarkStats");
        lunaStats = GameObject.Find("LunaStats");

        markHealth = GameObject.Find("MarkHealth");
        markStamina = GameObject.Find("MarkStamina");
        lunaHealth = GameObject.Find("LunaHealth");
        lunaStamina = GameObject.Find("LunaStamina");
        switcherLight = GameObject.Find("SwitcherLight");

        uiPanel = GameObject.Find("MainPanel");

    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (GetComponent<EventIssuer>().EventsAreOn())
        {
            foreach (GameObject g in nonDialogueUI)
            {
                g.SetActive(false);
            }
            dialogueUIObject.SetActive(true);

        }
        else if (!GetComponent<PauseManager>().IsPaused())
        {
            /*foreach (GameObject g in nonDialogueUI)
            {
                g.SetActive(true);
            }*/
            foreach (Transform child in uiPanel.transform)
            {
                child.gameObject.SetActive(true);
            }
            dialogueUIObject.SetActive(false);
        }
        else
        {
            foreach (Transform child in uiPanel.transform)
            {
                if (child.gameObject.name != "ScreenEffect")
                {
                    child.gameObject.SetActive(!GetComponent<PauseManager>().IsPaused());
                }
            }
        }

        if (GetComponent<DimensionManager>().switchIsAvailable)
        {
            switcherState++;
            if (switcherState > 6)
            {
                switcherState = 6;
            }
        }
        else
        {
            switcherState = -1;
        }

        if (switchFlashTimer > 0f)
        {
            switchFlashTimer -= Time.fixedDeltaTime;
        }

        if (GetComponent<DimensionManager>().currentDimension == Dimension.DIMENSION_A)
        {
            markStats.GetComponent<Image>().sprite = markHUDon;
            lunaStats.GetComponent<Image>().sprite = lunaHUD;
        }
        else
        {
            markStats.GetComponent<Image>().sprite = markHUD;
            lunaStats.GetComponent<Image>().sprite = lunaHUDon;
        }

        //mark health
        markHealth.GetComponent<RectTransform>().localScale = new Vector3(Mathf.RoundToInt(((float)mark.health / mark.maxHealth) * 100) / 100f, 1, 1);

        //mark stamina
        markStamina.GetComponent<RectTransform>().localScale = new Vector3(Mathf.RoundToInt(((float)mark.stamina / mark.maxStamina) * 100) / 100f, 1, 1);
        if (!mark.isExhausted)
        {
            markStamina.GetComponent<Image>().sprite = staminaBarNormal;
        }
        else
        {
            markStamina.GetComponent<Image>().sprite = staminaBarExhausted;
        }


        //luna health
        lunaHealth.GetComponent<RectTransform>().localScale = new Vector3(Mathf.RoundToInt(((float)luna.health / luna.maxHealth) * 100) / 100f, 1, 1);
        lunaHealth.GetComponent<RectTransform>().anchoredPosition = new Vector3(485 + Mathf.RoundToInt(((float)(luna.maxHealth - luna.health) / luna.maxHealth) * 100), -31, 0);

        //luna stamina
        lunaStamina.GetComponent<RectTransform>().localScale = new Vector3(Mathf.RoundToInt(((float)luna.stamina / luna.maxStamina) * 100) / 100f, 1, 1);
        lunaStamina.GetComponent<RectTransform>().anchoredPosition = new Vector3(485 + (Mathf.RoundToInt(((float)(luna.maxStamina - luna.stamina) / luna.maxStamina) * 100)), -39, 0);
        
        
        if (!luna.isExhausted)
        {
            lunaStamina.GetComponent<Image>().sprite = staminaBarNormal;
        }
        else
        {
            lunaStamina.GetComponent<Image>().sprite = staminaBarExhausted;
        }

        //switcher light
        

        if (GetComponent<DimensionManager>().switchIsAvailable && switcherState != -1)
        {
            switcherLight.GetComponent<Image>().sprite = switcherOnStates[switcherState];
        }
        else
        {
            switcherLight.GetComponent<Image>().sprite = switcherOff;
        }
    }

    void OnGUI()
    {
        UITools.DrawRect(new Rect(0, 0, Screen.width, Screen.height), UITools.ColorFromRGB(255, 255, 255, Mathf.Max(Mathf.FloorToInt(switchFlashTimer * (1 / 0.3f) * 255f), 0)));
    }

}
