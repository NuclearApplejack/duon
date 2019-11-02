using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour {
    public bool manualPaused = false;

    public bool gameIsPaused = false;
    public GameObject pauseMenuCanvas;
    public GameObject generalUI;

    public GameObject pausedPanel;
    public GameObject inventoryPanel;
    public GameObject skillsPanel;
    public GameObject optionsPanel;

    //inventory objs
    public int hoveredItemNum = 0;
    Item hoveredItem;
    public GameObject invBG;
    public GameObject itemSelector;

    #region quantities
    public Text qtCookieU;
    public Text qtCookieD;

    public Text qtIceCreamU;
    public Text qtIceCreamD;

    public Text qtSandwichU;
    public Text qtSandwichD;

    public Text qtSoupU;
    public Text qtSoupD;

    public Text qtDrinkU;
    public Text qtDrinkD;

    public Text qtPainkillerU;
    public Text qtPainkillerD;

    public Text qtTeaU;
    public Text qtTeaD;

    public Text qtUnitU;
    public Text qtUnitD;
    #endregion

    public Text itemName;
    public Text itemDesc;

    Vector3 itemSelectorFinalPos = new Vector3(-132, 102, 0);

    Sprite invBGa;
    Sprite invBGz;
    Sprite invSelectorA;
    Sprite invSelectorZ;

    //--

    //skills objs

    public GameObject skillSelector;
    public Text skillNameA;
    public Text skillDescriptionA;
    public Text skillNameZ;
    public Text skillDescriptionZ;
    public Image skillIconA;
    public Image skillIconZ;

    Vector3 skillSelectorFinalPos = new Vector3(-89.5f, 79.5f, 0);

    public int hoveredSkillNum = 0;
    public GeneralSkill hoveredSkillA;
    public GeneralSkill hoveredSkillZ;

    //--


    public PauseMenuState currentState = PauseMenuState.PAUSED;

    public AudioSource audioSource;
    public AudioClip cancelSound;
    public AudioClip navigateSound;
    public AudioClip selectSound;

    public int selectedOption = 0;

    

    Rigidbody2D[] rigidbodies;
    List<Vector3> rbVels = new List<Vector3>();


    GameObject invOption;
    GameObject skillsOption;
    GameObject optionsOption;
    GameObject exitOption;

    //public GameObject text


    GameObject[] options = new GameObject[4];


    // Use this for initialization
    void Start () {

        pauseMenuCanvas = GameObject.Find("PauseMenuUI");
        generalUI = GameObject.Find("GeneralUI");

        pausedPanel = GameObject.Find("PausedPanel");
        inventoryPanel = GameObject.Find("InventoryPanel");
        skillsPanel = GameObject.Find("SkillsPanel");
        optionsPanel = GameObject.Find("OptionsPanel");


        invOption = GameObject.Find("InventoryOption");
        skillsOption = GameObject.Find("SkillsOption");
        optionsOption = GameObject.Find("OptionsOption");
        exitOption = GameObject.Find("ExitOption");

        options[0] = invOption;
        options[1] = skillsOption;
        options[2] = optionsOption;
        options[3] = exitOption;

        audioSource = GetComponent<AudioSource>();

        //inv
        invBG = GameObject.Find("InventoryBG");
        itemSelector = GameObject.Find("ItemSelector");
        itemName = GameObject.Find("ItemName").GetComponent<Text>();
        itemDesc = GameObject.Find("ItemDescription").GetComponent<Text>();
        invBGa = Resources.Load<Sprite>("Graphics/UI/Pause Menu/Inventory/inventory a");
        invBGz = Resources.Load<Sprite>("Graphics/UI/Pause Menu/Inventory/inventory z");
        invSelectorA = Resources.Load<Sprite>("Graphics/UI/Pause Menu/Inventory/inventory selector a");
        invSelectorZ = Resources.Load<Sprite>("Graphics/UI/Pause Menu/Inventory/inventory selector z");
        #region quantities
        qtCookieU = GameObject.Find("QtCookieU").GetComponent<Text>();
        qtCookieD = GameObject.Find("QtCookieD").GetComponent<Text>();

        qtIceCreamU = GameObject.Find("QtIceCreamU").GetComponent<Text>();
        qtIceCreamD = GameObject.Find("QtIceCreamD").GetComponent<Text>();

        qtSandwichU = GameObject.Find("QtSandwichU").GetComponent<Text>();
        qtSandwichD = GameObject.Find("QtSandwichD").GetComponent<Text>();

        qtSoupU = GameObject.Find("QtSoupU").GetComponent<Text>();
        qtSoupD = GameObject.Find("QtSoupD").GetComponent<Text>();

        qtDrinkU = GameObject.Find("QtDrinkU").GetComponent<Text>();
        qtDrinkD = GameObject.Find("QtDrinkD").GetComponent<Text>();

        qtPainkillerU = GameObject.Find("QtPainkillerU").GetComponent<Text>();
        qtPainkillerD = GameObject.Find("QtPainkillerD").GetComponent<Text>();

        qtTeaU = GameObject.Find("QtTeaU").GetComponent<Text>();
        qtTeaD = GameObject.Find("QtTeaD").GetComponent<Text>();

        qtUnitU = GameObject.Find("QtUnitU").GetComponent<Text>();
        qtUnitD = GameObject.Find("QtUnitD").GetComponent<Text>();
        #endregion

        //skills
        skillSelector = GameObject.Find("SkillsSelector");
        skillNameA = GameObject.Find("SkillNameA").GetComponent<Text>();
        skillDescriptionA = GameObject.Find("SkillDescriptionA").GetComponent<Text>();
        skillNameZ = GameObject.Find("SkillNameZ").GetComponent<Text>();
        skillDescriptionZ = GameObject.Find("SkillDescriptionZ").GetComponent<Text>();
        skillIconA = GameObject.Find("SkillIconA").GetComponent<Image>();
        skillIconZ = GameObject.Find("SkillIconZ").GetComponent<Image>();

        pauseMenuCanvas.SetActive(gameIsPaused);
        
        InvokeRepeating("UpdatePausedUIStates", 0, 0.1f);
    }
	
	// Update is called once per frame
	void Update () {
        if (gameIsPaused)
        {
            if (currentState == PauseMenuState.PAUSED)
            {
                #region paused
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    TogglePause();
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    selectedOption--;
                    if (selectedOption < 0)
                    {
                        selectedOption = 4 + selectedOption;
                    }

                    selectedOption = selectedOption % 4;

                    audioSource.PlayOneShot(navigateSound);
                }

                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    selectedOption++;
                    selectedOption = selectedOption % 4;

                    audioSource.PlayOneShot(navigateSound);
                }

                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
                {
                    if (selectedOption == 0)
                    {
                        currentState = PauseMenuState.INVENTORY;
                        hoveredItemNum = 0;
                        selectedOption = 0;
                        if (GetComponent<DimensionManager>().currentDimension == Dimension.DIMENSION_A)
                        {
                            invBG.GetComponent<Image>().sprite = invBGa;
                            itemSelector.GetComponent<Image>().sprite = invSelectorA;
                        }
                        else
                        {
                            invBG.GetComponent<Image>().sprite = invBGz;
                            itemSelector.GetComponent<Image>().sprite = invSelectorZ;
                        }

                        audioSource.PlayOneShot(selectSound);
                    }
                    else if (selectedOption == 1)
                    {
                        currentState = PauseMenuState.SKILLS;
                        hoveredSkillNum = 0;
                        selectedOption = 0;

                        audioSource.PlayOneShot(selectSound);
                    }
                    else if (selectedOption == 2)
                    {
                        //currentState = PauseMenuState.OPTIONS;
                        audioSource.PlayOneShot(cancelSound);
                    }
                    else
                    {
                        audioSource.PlayOneShot(selectSound);

                        if (SceneManager.GetActiveScene().name == "MainLab")
                        {
                            GetComponent<SceneTransitioner>().TransitionWithFade("TitleScreen", Color.black);
                        }
                        else
                        {
                            GetComponent<SceneTransitioner>().TransitionWithFade("MainLab", Color.black);
                        }
                    }
                }

                #endregion
            }
            else if (currentState == PauseMenuState.INVENTORY)
            {
                #region inventory

                UpdateItemStats();

                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    currentState = PauseMenuState.PAUSED;
                    UpdatePausedUIStates();

                    audioSource.PlayOneShot(navigateSound);
                }
                else if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
                {
                    if (hoveredItemNum == 0)
                    {
                        if (InventoryHolder.cookies.Count > 0)
                        {
                            InventoryHolder.cookies.RemoveAt(InventoryHolder.cookies.Count - 1);
                            hoveredItem.OnUse(GetComponent<DimensionManager>().GetCurrentCharacter().GetComponent<PlayableCharacter>());
                            GetComponent<AudioSource>().PlayOneShot(Resources.Load<AudioClip>("Sound/SFX/Misc/heal"), 0.8f);
                        }
                    }
                    else if (hoveredItemNum == 1)
                    {
                        if (InventoryHolder.iceCreams.Count > 0)
                        {
                            InventoryHolder.iceCreams.RemoveAt(InventoryHolder.iceCreams.Count - 1);
                            hoveredItem.OnUse(GetComponent<DimensionManager>().GetCurrentCharacter().GetComponent<PlayableCharacter>());
                            GetComponent<AudioSource>().PlayOneShot(Resources.Load<AudioClip>("Sound/SFX/Misc/heal"), 0.8f);
                        }
                    }
                    else if (hoveredItemNum == 2)
                    {
                        if (InventoryHolder.sandwiches.Count > 0)
                        {
                            InventoryHolder.sandwiches.RemoveAt(InventoryHolder.sandwiches.Count - 1);
                            hoveredItem.OnUse(GetComponent<DimensionManager>().GetCurrentCharacter().GetComponent<PlayableCharacter>());
                            GetComponent<AudioSource>().PlayOneShot(Resources.Load<AudioClip>("Sound/SFX/Misc/heal"), 0.8f);
                        }
                    }
                    else if (hoveredItemNum == 3)
                    {
                        if (InventoryHolder.soups.Count > 0)
                        {
                            InventoryHolder.soups.RemoveAt(InventoryHolder.soups.Count - 1);
                            hoveredItem.OnUse(GetComponent<DimensionManager>().GetCurrentCharacter().GetComponent<PlayableCharacter>());
                            GetComponent<AudioSource>().PlayOneShot(Resources.Load<AudioClip>("Sound/SFX/Misc/heal"), 0.8f);
                        }
                    }
                    else
                    {
                        
                    }
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    hoveredItemNum++;
                    hoveredItemNum = hoveredItemNum % 8;

                    if (hoveredItemNum == 4)
                    {
                        hoveredItemNum = 0;
                    }
                    else if (hoveredItemNum == 0)
                    {
                        hoveredItemNum = 4;
                    }

                    audioSource.PlayOneShot(navigateSound);
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    if (hoveredItemNum == 0)
                    {
                        hoveredItemNum = 3;
                    }
                    else if (hoveredItemNum == 4)
                    {
                        hoveredItemNum = 7;
                    }
                    else
                    {
                        hoveredItemNum--;
                    }

                    audioSource.PlayOneShot(navigateSound);
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    hoveredItemNum += 4;
                    hoveredItemNum = hoveredItemNum % 8;

                    audioSource.PlayOneShot(navigateSound);
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    hoveredItemNum += 4;
                    hoveredItemNum = hoveredItemNum % 8;

                    audioSource.PlayOneShot(navigateSound);
                }
                

                #endregion
            }
            else if (currentState == PauseMenuState.SKILLS)
            {
                #region skills
                UpdateSkillStats();

                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    currentState = PauseMenuState.PAUSED;
                    UpdatePausedUIStates();

                    audioSource.PlayOneShot(navigateSound);
                }
                else if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
                {

                }
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    
                    hoveredSkillNum++;
                    if (hoveredSkillNum % 3 == 0)
                    {
                        hoveredSkillNum -= 3;
                    }

                    audioSource.PlayOneShot(navigateSound);
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    hoveredSkillNum--;
                    if (hoveredSkillNum == -1)
                    {
                        hoveredSkillNum = 2;
                    }
                    else if (hoveredSkillNum == 2)
                    {
                        hoveredSkillNum = 5;
                    }

                    audioSource.PlayOneShot(navigateSound);
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    hoveredSkillNum += 3;
                    if (hoveredSkillNum > 5)
                    {
                        hoveredSkillNum -= 6;
                    }

                    audioSource.PlayOneShot(navigateSound);
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    hoveredSkillNum += 3;
                    if (hoveredSkillNum > 5)
                    {
                        hoveredSkillNum -= 6;
                    }

                    audioSource.PlayOneShot(navigateSound);
                }
                #endregion
            }
            else if (currentState == PauseMenuState.OPTIONS)
            {
                #region options
                if (Input.GetKeyDown(KeyCode.Escape))
                {

                }
                else if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
                {

                }
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {

                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow))
                {

                }
                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {

                }
                else if (Input.GetKeyDown(KeyCode.UpArrow))
                {

                }
                #endregion
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!GetComponent<EventIssuer>().EventsAreOn() && !manualPaused && !gameIsPaused)
            {

                TogglePause();
            }
        }

        foreach (GameObject g in options)
        {
            g.GetComponent<Animator>().SetBool("DimensionA", GetComponent<DimensionManager>().currentDimension == Dimension.DIMENSION_A);
        }

        UpdatePanels();

    }

    void UpdatePausedUIStates() {
        for (int i = 0; i < options.Length; i++)
        {
            if (i == selectedOption)
            {
                options[i].GetComponent<Animator>().SetBool("IsSelected", true);
            }
            else
            {
                options[i].GetComponent<Animator>().SetBool("IsSelected", false);
            }
        }
    }

    void UpdatePanels()
    {
        if (currentState == PauseMenuState.PAUSED)
        {
            pausedPanel.SetActive(true);
            inventoryPanel.SetActive(false);
            skillsPanel.SetActive(false);
            optionsPanel.SetActive(false);
            foreach (GameObject g in options)
            {
                g.GetComponent<Animator>().SetBool("DimensionA", GetComponent<DimensionManager>().currentDimension == Dimension.DIMENSION_A);
            }
        }
        else if (currentState == PauseMenuState.INVENTORY)
        {
            pausedPanel.SetActive(false);
            inventoryPanel.SetActive(true);
            skillsPanel.SetActive(false);
            optionsPanel.SetActive(false);
        }
        else if (currentState == PauseMenuState.SKILLS)
        {
            pausedPanel.SetActive(false);
            inventoryPanel.SetActive(false);
            skillsPanel.SetActive(true);
            optionsPanel.SetActive(false);
        }
        else if (currentState == PauseMenuState.OPTIONS)
        {
            pausedPanel.SetActive(false);
            inventoryPanel.SetActive(false);
            skillsPanel.SetActive(false);
            optionsPanel.SetActive(true);
        }
        
    }

    void TogglePause()
    {
        gameIsPaused = !gameIsPaused;

        
        pauseMenuCanvas.SetActive(gameIsPaused);

        rigidbodies = FindObjectsOfType<Rigidbody2D>();
        Animator[] animators = FindObjectsOfType<Animator>();

        if (gameIsPaused)
        {
            rbVels.Clear();
            selectedOption = 0;
            foreach (Rigidbody2D rb2d in rigidbodies)
            {
                rbVels.Add(rb2d.velocity);
                rb2d.Sleep();
            }
            foreach (Animator animator in animators)
            {
                if (!animator.gameObject.CompareTag("Pause UI"))
                {
                    animator.speed = 0f;
                }
                
            }

            UpdatePausedUIStates();
            audioSource.PlayOneShot(navigateSound);
        }
        else
        {
            int velCounter = 0;
            foreach (Rigidbody2D rb2d in rigidbodies)
            {
                rb2d.WakeUp();
                rb2d.velocity = rbVels[velCounter];
                velCounter++;
            }
            foreach (Animator animator in animators)
            {
                if (!animator.gameObject.CompareTag("Pause UI"))
                {
                    animator.speed = 1f;
                }
            }
        }


    }

    public bool IsPaused()
    {
        return (gameIsPaused || manualPaused);
    }

    public void UpdateItemStats()
    {
        

        if (hoveredItemNum == 0)
        {
            hoveredItem = new Cookie();
        }
        else if (hoveredItemNum == 1)
        {
            hoveredItem = new IceCream();
        }
        else if (hoveredItemNum == 2)
        {
            hoveredItem = new TripleSandwich();
        }
        else if (hoveredItemNum == 3)
        {
            hoveredItem = new LilithsChickenSoup();
        }
        else if(hoveredItemNum == 4)
        {
            hoveredItem = new EnergyDrink();
        }
        else if (hoveredItemNum == 5)
        {
            hoveredItem = new Painkiller();
        }
        else if(hoveredItemNum == 6)
        {
            hoveredItem = new ChamomileTea();
        }
        else
        {
            hoveredItem = new BlastingUnit();
        }

        itemName.text = hoveredItem.itemName;
        itemDesc.text = hoveredItem.description;

        itemSelectorFinalPos = new Vector3(-132 + ((hoveredItemNum % 4) * 88), 102 + (Mathf.FloorToInt(hoveredItemNum / 4) * -82), 0);

        itemSelector.transform.localPosition += (itemSelectorFinalPos - itemSelector.transform.localPosition) / 2f;

        #region quantities

        qtCookieU.text = (InventoryHolder.cookies.Count % 10).ToString();
        qtCookieD.text = Mathf.FloorToInt(InventoryHolder.cookies.Count / 10).ToString();

        qtIceCreamU.text = (InventoryHolder.iceCreams.Count % 10).ToString();
        qtIceCreamD.text = Mathf.FloorToInt(InventoryHolder.iceCreams.Count / 10).ToString();

        qtSandwichU.text = (InventoryHolder.sandwiches.Count % 10).ToString();
        qtSandwichD.text = Mathf.FloorToInt(InventoryHolder.sandwiches.Count / 10).ToString();

        qtSoupU.text = (InventoryHolder.soups.Count % 10).ToString();
        qtSoupD.text = Mathf.FloorToInt(InventoryHolder.soups.Count / 10).ToString();

        qtDrinkU.text = (InventoryHolder.energyDrinks.Count % 10).ToString();
        qtDrinkD.text = Mathf.FloorToInt(InventoryHolder.energyDrinks.Count / 10).ToString();

        qtPainkillerU.text = (InventoryHolder.painkillers.Count % 10).ToString();
        qtPainkillerD.text = Mathf.FloorToInt(InventoryHolder.painkillers.Count / 10).ToString();

        qtTeaU.text = (InventoryHolder.teas.Count % 10).ToString();
        qtTeaD.text = Mathf.FloorToInt(InventoryHolder.teas.Count / 10).ToString();

        qtUnitU.text = (InventoryHolder.blastingUnits.Count % 10).ToString();
        qtUnitD.text = Mathf.FloorToInt(InventoryHolder.blastingUnits.Count / 10).ToString();

        #endregion
    }

    public void UpdateSkillStats()
    {
        if (hoveredSkillNum == 0)
        {
            hoveredSkillA = SkillsHolder.markSkillSlot1;
            hoveredSkillZ = SkillsHolder.lunaSkillSlot1;
        }
        else if (hoveredSkillNum == 1)
        {
            hoveredSkillA = SkillsHolder.markSkillSlot2;
            hoveredSkillZ = SkillsHolder.lunaSkillSlot2;
        }
        else if (hoveredSkillNum == 2)
        {
            hoveredSkillA = SkillsHolder.markSkillSlot3;
            hoveredSkillZ = SkillsHolder.lunaSkillSlot3;
        }
        else if (hoveredSkillNum == 3)
        {
            hoveredSkillA = SkillsHolder.markSkillSlot4;
            hoveredSkillZ = SkillsHolder.lunaSkillSlot4;
        }
        else if (hoveredSkillNum == 4)
        {
            hoveredSkillA = SkillsHolder.markSkillSlot5;
            hoveredSkillZ = SkillsHolder.lunaSkillSlot5;
        }
        else if (hoveredSkillNum == 5)
        {
            hoveredSkillA = SkillsHolder.markSkillSlot6;
            hoveredSkillZ = SkillsHolder.lunaSkillSlot6;
        }

        skillSelectorFinalPos = new Vector3(-89.5f + ((hoveredSkillNum % 3) * 88), 79.5f + (Mathf.FloorToInt(hoveredSkillNum / 3) * -74), 0);

        skillSelector.transform.localPosition += (skillSelectorFinalPos - skillSelector.transform.localPosition) / 2f;

        if (hoveredSkillA == null || hoveredSkillZ == null)
        {
            skillNameA.text = "???";
            skillNameZ.text = "???";
            skillDescriptionA.text = "You have not unlocked this Skill yet. Earn EXP and level up to unlock additional Skills.\n\nNot available in the demo.";
            skillDescriptionZ.text = "You have not unlocked this Skill yet. Earn EXP and level up to unlock additional Skills.\n\nNot available in the demo.";
            skillIconA.sprite = Resources.Load<Sprite>("Graphics/UI/Pause Menu/Skills/unknown mark icon");
            skillIconZ.sprite = Resources.Load<Sprite>("Graphics/UI/Pause Menu/Skills/unknown luna icon");
            return;
        }

        skillNameA.text = hoveredSkillA.name;
        skillNameZ.text = hoveredSkillZ.name;

        string descriptionA = "";
        if (hoveredSkillA is GeneralBasicSkill)
        {
            descriptionA += "Basic Skill\n";
            descriptionA += "Type: " + ((PlayerBasicSkill)hoveredSkillA).type.ToString() + "\n";
            descriptionA += ((PlayerBasicSkill)hoveredSkillA).description;
        }
        else
        {
            descriptionA += "Art\n";
            descriptionA += "Requires: ";

            foreach (BasicSkillType requirement in ((PlayerArt)hoveredSkillA).basicSkillRequirements)
            {
                descriptionA += requirement.ToString() + " > ";
            }

            descriptionA = descriptionA.Remove(descriptionA.Length - 3);
            descriptionA += "\n";
            descriptionA += ((PlayerArt)hoveredSkillA).description;
        }
        skillDescriptionA.text = descriptionA;
        skillIconA.sprite = hoveredSkillA.icon;

        string descriptionZ = "";
        if (hoveredSkillZ is GeneralBasicSkill)
        {
            descriptionZ += "Basic Skill\n";
            descriptionZ += "Type: " + ((PlayerBasicSkill)hoveredSkillZ).type.ToString() + "\n";
            descriptionZ += ((PlayerBasicSkill)hoveredSkillZ).description;
        }
        else
        {
            descriptionZ += "Art\n";
            descriptionZ += "Requires: ";

            foreach (BasicSkillType requirement in ((PlayerArt)hoveredSkillZ).basicSkillRequirements)
            {
                descriptionZ += requirement.ToString() + " > ";
            }

            descriptionZ = descriptionZ.Remove(descriptionZ.Length - 3);
            descriptionZ += "\n";
            descriptionZ += ((PlayerArt)hoveredSkillZ).description;
        }
        skillDescriptionZ.text = descriptionZ;
        skillIconZ.sprite = hoveredSkillZ.icon;
    }
}
