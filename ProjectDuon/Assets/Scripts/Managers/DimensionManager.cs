using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimensionManager : MonoBehaviour {

    

    GameObject mark;
    GameObject luna;

    AudioClip switchSound;

    //for exploration phase
    float explorationSwitchDelay = 1f;
    public float currentExplorationSwitchDelay = 0;
    //--

    //for battle phase

    
    //--

    
    
    
    public bool switchIsAvailable = true;

    [HideInInspector]
    public Dimension currentDimension = CurrentDimensionHolder.currentDimension;

    void Start()
    {
        switchSound = Resources.Load<AudioClip>("Sound/SFX/Misc/DimensionalSwitch");
        currentDimension = CurrentDimensionHolder.currentDimension;
        mark = GameObject.Find("Mark");
        luna = GameObject.Find("Luna");
    }

    void SwitchDimensions()
    {
        if (currentDimension == Dimension.DIMENSION_A)
        {
            currentDimension = Dimension.DIMENSION_Z;
        }
        else
        {
            currentDimension = Dimension.DIMENSION_A;
        }

        GetComponent<AudioSource>().PlayOneShot(switchSound, 0.8f);
        CurrentDimensionHolder.currentDimension = currentDimension;
        
    }

    void DetermineSwitchAvailability()
    {
        if (GetComponent<PauseManager>().IsPaused())
        {
            switchIsAvailable = false;
            return;
        }

        if (mark.GetComponent<Mark>().isTakingAction || luna.GetComponent<Luna>().isTakingAction || !mark.GetComponent<Mark>().grounded || !luna.GetComponent<Luna>().grounded)
        {
            switchIsAvailable = false;
            return;
        }
        

        if (GetComponent<PhaseManager>().currentPhase == GameplayPhase.EXPLORATION)
        {
            if (currentExplorationSwitchDelay <= 0)
            {
                switchIsAvailable = true;
            }
            else
            {
                switchIsAvailable = false;
            }
        }
        else
        {

        }
    }

    void Update()
    {
        
        DetermineSwitchAvailability();

        if (switchIsAvailable)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                SwitchDimensions();
                currentExplorationSwitchDelay = explorationSwitchDelay;
                GetComponent<UIManager>().switchFlashTimer = 0.3f;
            }
        }

        if (currentExplorationSwitchDelay > 0)
        {
            currentExplorationSwitchDelay -= Time.deltaTime;
        }
        
    }

    public GameObject GetCurrentCharacter()
    {
        if (currentDimension == Dimension.DIMENSION_A)
        {
            return mark;
        }
        else
        {
            return luna;
        }
    }
}
