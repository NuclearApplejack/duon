using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class HollowAlpha : GeneralOutmarrow {

    GameObject mark;
    GameObject luna;
    
    GameObject laserBeam;
    GameObject explo;



    public HollowAlphaState state = HollowAlphaState.ASLEEP;

    bool facingRight = false;
    bool hasDied = false;

    float actionTimer = 0f;
    float actionDelay = 5f;

    Animator animator;

	// Use this for initialization
	void Start () {
        state = HollowAlphaState.ASLEEP;
        maxHealth = 10000;
        maxShield = 2000;
        currentHealth = maxHealth;
        currentShield = maxShield;
        shieldRegenRate = 175;

        animator = GetComponent<Animator>();
        mark = GameObject.Find("Mark");
        luna = GameObject.Find("Luna");
        generalManager = GameObject.Find("GeneralManager");
        laserBeam = transform.Find("LaserBeam").gameObject;
        explo = transform.Find("Explo").gameObject;
    }

    // Update is called once per frame
    /*
    new void Update () {
        base.Update();

        if (generalManager.GetComponent<DimensionManager>().currentDimension == Dimension.DIMENSION_A)
        {
            if (mark.transform.position.x < transform.position.x)
            {
                facingRight = false;
            }

            else
            {
                facingRight = true;
            }
        }
        else
        {
            if (luna.transform.position.x < transform.position.x)
            {
                facingRight = false;
            }
            else
            {
                facingRight = true;
            }
        }

        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Laser"))
        {
            if (facingRight)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }

		if (laserTimer < laserDelay)
        {
            laserTimer += Time.deltaTime;
        }
        else
        {
            laserTimer = 0f;
            animator.SetTrigger("FireLaser");
            laserBeam.GetComponent<Animator>().SetTrigger("Fire");
        }
	}*/

    new void Update()
    {
        base.Update();

        if (currentHealth > 0)
        {
            if (state == HollowAlphaState.IDLE)
            {
                if (generalManager.GetComponent<DimensionManager>().currentDimension == Dimension.DIMENSION_A)
                {
                    if (mark.transform.position.x < transform.position.x)
                    {
                        facingRight = false;
                    }

                    else
                    {
                        facingRight = true;
                    }
                }
                else
                {
                    if (luna.transform.position.x < transform.position.x)
                    {
                        facingRight = false;
                    }
                    else
                    {
                        facingRight = true;
                    }
                }

                if (facingRight)
                {
                    transform.localScale = new Vector3(-1, 1, 1);

                }
                else
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }

                if (!generalManager.GetComponent<PauseManager>().gameIsPaused)
                {
                    if (actionTimer < actionDelay)
                    {
                        actionTimer += Time.deltaTime;
                    }
                    else
                    {
                        actionTimer = 0f;
                        if (Random.Range(0, 2) == 0)
                        {
                            state = HollowAlphaState.LASER_BEAM;
                            animator.SetTrigger("FireLaser");
                            laserBeam.GetComponent<Animator>().SetTrigger("Fire");
                        }
                        else
                        {
                            state = HollowAlphaState.EXPLO;
                            animator.SetTrigger("FireExplo");
                            explo.GetComponent<Animator>().SetTrigger("Fire");
                        }
                    }
                }
            }
        }
        else
        {
            if (!hasDied)
            {
                animator.SetTrigger("Die");
                Destroy(laserBeam);
                Destroy(explo);
                hasDied = true;
            }
        }
    }

    public void ReturnToDefaultState()
    {
        state = HollowAlphaState.IDLE;
    }
}
