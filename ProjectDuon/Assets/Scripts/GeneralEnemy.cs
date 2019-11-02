using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralEnemy : MonoBehaviour {

    public int maxHealth;
    public int currentHealth;
    public int maxShield;
    public int currentShield;

    public float shieldRegenDelay;
    public int shieldRegenRate;

    public float delayUntilShieldRegen = 0f;

    public GameObject generalManager;


    // Use this for initialization
    void Start () {
        generalManager = GameObject.Find("GeneralManager");
	}

    // Update is called once per frame
    public void Update()
    {
        if (!generalManager.GetComponent<PauseManager>().IsPaused())
        {
            if (currentHealth > 0)
            {
                if (delayUntilShieldRegen <= 0f)
                {
                    if (currentShield < maxShield)
                    {
                        currentShield += Mathf.CeilToInt(shieldRegenRate * Time.deltaTime);
                    }
                }
                else
                {
                    delayUntilShieldRegen -= Time.deltaTime;
                }

                if (currentShield < 0)
                {
                    currentShield = 0;
                }
                if (currentHealth < 0)
                {
                    currentHealth = 0;
                }
            }
        }
    }

    public void TakeDamage(int damage)
    {
        
        if (currentShield > 0)
        {
            currentShield -= damage;
        }
        else
        {
            delayUntilShieldRegen = 2f;
            currentHealth -= damage;
        }
    }




}
