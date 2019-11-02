using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboManager : MonoBehaviour {

    public List<PlayerBasicSkill> basicSkillsUsed = new List<PlayerBasicSkill>();

    public Text skillsUsedText;
    public Text hitsText;

    GameObject comboCounter;
    public Image units;
    public Image tens;
    public Image hundreds;
    public Image hitsImage;

    public Text markSkillText;
    public Text lunaSkillText;
    public List<Text> markSkillOutlineTexts = new List<Text>();
    public List<Text> lunaSkillOutlineTexts = new List<Text>();

    public int hits = 0;

    public Sprite[] sprites = new Sprite[10];

    float comboColorChangeInterval = 15f;

    public float comboTimeout = 0f;

    
    public string markSkillName = "";
    public float markSkillTimer = 0f;

    public string lunaSkillName = "";
    public float lunaSkillTimer = 0f;

    float comboShakeFactor = 0f;
    float comboShakeAngle = 0f;


    // Use this for initialization
    void Start () {
        comboCounter = GameObject.Find("ComboCounter");
        units = GameObject.Find("ComboUnits").GetComponent<Image>();
        tens = GameObject.Find("ComboTens").GetComponent<Image>();
        hundreds = GameObject.Find("ComboHundreds").GetComponent<Image>();
        hitsImage = GameObject.Find("ComboHits").GetComponent<Image>();

        markSkillOutlineTexts.Add(GameObject.Find("MarkSkill").GetComponent<Text>());
        markSkillOutlineTexts.Add(GameObject.Find("MarkSkillU").GetComponent<Text>());
        markSkillOutlineTexts.Add(GameObject.Find("MarkSkillD").GetComponent<Text>());
        markSkillOutlineTexts.Add(GameObject.Find("MarkSkillL").GetComponent<Text>());
        markSkillOutlineTexts.Add(GameObject.Find("MarkSkillR").GetComponent<Text>());
        markSkillOutlineTexts.Add(GameObject.Find("MarkSkillUR").GetComponent<Text>());
        markSkillOutlineTexts.Add(GameObject.Find("MarkSkillUL").GetComponent<Text>());
        markSkillOutlineTexts.Add(GameObject.Find("MarkSkillDR").GetComponent<Text>());
        markSkillOutlineTexts.Add(GameObject.Find("MarkSkillDL").GetComponent<Text>());

        lunaSkillOutlineTexts.Add(GameObject.Find("LunaSkill").GetComponent<Text>());
        lunaSkillOutlineTexts.Add(GameObject.Find("LunaSkillU").GetComponent<Text>());
        lunaSkillOutlineTexts.Add(GameObject.Find("LunaSkillR").GetComponent<Text>());
        lunaSkillOutlineTexts.Add(GameObject.Find("LunaSkillD").GetComponent<Text>());
        lunaSkillOutlineTexts.Add(GameObject.Find("LunaSkillL").GetComponent<Text>());
        lunaSkillOutlineTexts.Add(GameObject.Find("LunaSkillUR").GetComponent<Text>());
        lunaSkillOutlineTexts.Add(GameObject.Find("LunaSkillUL").GetComponent<Text>());
        lunaSkillOutlineTexts.Add(GameObject.Find("LunaSkillDR").GetComponent<Text>());
        lunaSkillOutlineTexts.Add(GameObject.Find("LunaSkillDL").GetComponent<Text>());

        sprites[0] = Resources.Load<Sprite>("Graphics/UI/Main UI/Combo Counter/combo 0");
        sprites[1] = Resources.Load<Sprite>("Graphics/UI/Main UI/Combo Counter/combo 1");
        sprites[2] = Resources.Load<Sprite>("Graphics/UI/Main UI/Combo Counter/combo 2");
        sprites[3] = Resources.Load<Sprite>("Graphics/UI/Main UI/Combo Counter/combo 3");
        sprites[4] = Resources.Load<Sprite>("Graphics/UI/Main UI/Combo Counter/combo 4");
        sprites[5] = Resources.Load<Sprite>("Graphics/UI/Main UI/Combo Counter/combo 5");
        sprites[6] = Resources.Load<Sprite>("Graphics/UI/Main UI/Combo Counter/combo 6");
        sprites[7] = Resources.Load<Sprite>("Graphics/UI/Main UI/Combo Counter/combo 7");
        sprites[8] = Resources.Load<Sprite>("Graphics/UI/Main UI/Combo Counter/combo 8");
        sprites[9] = Resources.Load<Sprite>("Graphics/UI/Main UI/Combo Counter/combo 9");

        //InvokeRepeating("UpdateComboCounterShaking", 0f, 0.1f);
    }
	
	// Update is called once per frame
	void Update () {
        if (!GetComponent<PauseManager>().gameIsPaused)
        {
            if (comboTimeout > 0f)
            {
                comboTimeout -= Time.deltaTime;
            }
            else
            {
                hits = 0;
            }

            UpdateComboCounterShaking();
            UpdateComboCounter();
            UpdateSkillNames();
        }

    }

    public bool DetermineIfArtCanBeUsed(GeneralArt art)
    {
        if (art.basicSkillRequirements.Count > basicSkillsUsed.Count)
        {
            return false;
        }


        for (int i = 1; i <= art.basicSkillRequirements.Count; i++)
        {
            if (basicSkillsUsed[basicSkillsUsed.Count - i].type != art.basicSkillRequirements[art.basicSkillRequirements.Count - i])
            {
                return false;
            }
        }

        return true;
        
    }

    public void UpdateComboCounter()
    {
        float r;
        float g;
        float b;

        if (hits > 0 && hits <= comboColorChangeInterval)
        {
            r = 1 - (hits / comboColorChangeInterval);
            g = 1;
            b = 1;
        }
        else if (hits > comboColorChangeInterval && hits <= (comboColorChangeInterval * 2))
        {
            r = 0;
            g = 1 - ((hits - comboColorChangeInterval) / comboColorChangeInterval);
            b = 1;
        }
        else if (hits > (comboColorChangeInterval * 2) && hits <= (comboColorChangeInterval * 3))
        {
            r = (hits - (comboColorChangeInterval * 2)) / comboColorChangeInterval;
            g = 0;
            b = 1;
        }
        else if (hits > (comboColorChangeInterval * 3) && hits <= (comboColorChangeInterval * 4))
        {
            r = 1;
            g = 0;
            b = 1 - ((hits - (comboColorChangeInterval * 3)) / comboColorChangeInterval);
        }
        else
        {
            r = 1;
            b = 0;
            g = 0;
        }

        if (hits == 0)
        {
            units.color = new Color(r, g, b, 0);
            tens.color = new Color(r, g, b, 0);
            hundreds.color = new Color(r, g, b, 0);
            hitsImage.color = new Color(r, g, b, 0);
        }
        else if (hits < 10)
        {
            units.color = new Color(r, g, b, 1);
            tens.color = new Color(r, g, b, 0);
            hundreds.color = new Color(r, g, b, 0);
            hitsImage.color = new Color(r, g, b, 1);

            comboCounter.transform.localPosition = new Vector3(-13, comboCounter.transform.localPosition.y, 0);
        }
        else if (hits < 100)
        {
            units.color = new Color(r, g, b, 1);
            tens.color = new Color(r, g, b, 1);
            hundreds.color = new Color(r, g, b, 0);
            hitsImage.color = new Color(r, g, b, 1);

            comboCounter.transform.localPosition = new Vector3(-5, comboCounter.transform.localPosition.y, 0);
        }
        else
        {
            units.color = new Color(r, g, b, 1);
            tens.color = new Color(r, g, b, 1);
            hundreds.color = new Color(r, g, b, 1);
            hitsImage.color = new Color(r, g, b, 1);

            comboCounter.transform.localPosition = new Vector3(3, comboCounter.transform.localPosition.y, 0);
        }

        units.sprite = sprites[hits % 10];
        tens.sprite = sprites[Mathf.FloorToInt(hits / 10f) % 10];
        hundreds.sprite = sprites[Mathf.FloorToInt(hits / 100f) % 10];
    }

    public void UpdateSkillNames()
    {
        if (markSkillTimer > 0f)
        {
            markSkillTimer -= Time.deltaTime;
        }
        if (lunaSkillTimer > 0f)
        {
            lunaSkillTimer -= Time.deltaTime;
        }


        //mark
        float markColorA;

        if (markSkillTimer < 0f)
        {
            markColorA = 0f;
        }
        else if (markSkillTimer < 1f)
        {
            markColorA = markSkillTimer;
        }
        else
        {
            markColorA = 1f;
        }

        foreach (Text text in markSkillOutlineTexts)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, markColorA);
            text.text = markSkillName;
        }


        //luna
        float lunaColorA;

        if (lunaSkillTimer < 0f)
        {
            lunaColorA = 0f;
        }
        else if (lunaSkillTimer < 1f)
        {
            lunaColorA = lunaSkillTimer;
        }
        else
        {
            lunaColorA = 1f;
        }

        foreach (Text text in lunaSkillOutlineTexts)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, lunaColorA);
            text.text = lunaSkillName;
        }

        
        
    }

    public void UpdateComboCounterShaking()
    {
        if (comboShakeFactor > 0f)
        {
            comboShakeFactor -= 0.2f;
            comboShakeAngle = (comboShakeAngle + 90 + Random.Range(0, 181)) % 360;
            units.transform.localPosition = new Vector3(Mathf.Cos(Mathf.Deg2Rad * comboShakeAngle) * comboShakeFactor, Mathf.Sin(Mathf.Deg2Rad * comboShakeAngle) * comboShakeFactor, 0);

            comboShakeAngle = (comboShakeAngle + 90 + Random.Range(0, 181)) % 360;
            tens.transform.localPosition = new Vector3((Mathf.Cos(Mathf.Deg2Rad * comboShakeAngle) * comboShakeFactor) - 16, Mathf.Sin(Mathf.Deg2Rad * comboShakeAngle) * comboShakeFactor, 0);

            comboShakeAngle = (comboShakeAngle + 90 + Random.Range(0, 181)) % 360;
            hundreds.transform.localPosition = new Vector3((Mathf.Cos(Mathf.Deg2Rad * comboShakeAngle) * comboShakeFactor) - 32, Mathf.Sin(Mathf.Deg2Rad * comboShakeAngle) * comboShakeFactor, 0);

            comboShakeAngle = (comboShakeAngle + 90 + Random.Range(0, 181)) % 360;
            hitsImage.transform.localPosition = new Vector3((Mathf.Cos(Mathf.Deg2Rad * comboShakeAngle) * comboShakeFactor) + 21.5f, Mathf.Sin(Mathf.Deg2Rad * comboShakeAngle) * comboShakeFactor, 0);
        }
    }

    public void IncrementHits()
    {
        IncrementHits(1);

    }

    public void IncrementHits(int hitCount)
    {
        hits += hitCount;
        //comboShakeFactor = Mathf.Min(Mathf.CeilToInt(hits / 15f), 3f);
        comboShakeFactor = Mathf.Min(hits / 15f, 2f) + 1f;
        comboTimeout = 5f;

    }

    public void EndCombo()
    {
        hits = 0;
    }

}
