using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FissureRushHitbox1 : PlayerHitbox
{
    GameObject generalManager;
    AudioSource audioSource;
    GameObject luna;

    // Use this for initialization
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        luna = GameObject.Find("Luna");
        generalManager = GameObject.Find("GeneralManager");
    }

    // Update is called once per frame
    void Update()
    {

    }

    new void OnTriggerEnter2D(Collider2D c)
    {

        if (c.tag == "EnemyHurtbox")
        {
            c.transform.parent.gameObject.GetComponent<GeneralEnemy>().TakeDamage(damage);
            generalManager.GetComponent<ComboManager>().IncrementHits();
            //GameObject damageEffect = Instantiate(Resources.Load("Prefabs/PlasmaDamage")) as GameObject;
            if (luna.GetComponent<Luna>().isFacingRight)
            {
                //damageEffect.transform.position = new Vector3(transform.position.x + 9, transform.position.y, -1.5f);
            }
            else
            {
                //damageEffect.transform.position = new Vector3(transform.position.x - 9, transform.position.y, -1.5f);
            }
            //StartCoroutine(generalManager.GetComponent<EventIssuer>().ShakeScreenDuringGameplay(0.4f, 0.05f));
            //audioSource.PlayOneShot(soundEffect, 0.8f);
        }
        base.OnTriggerEnter2D(c);
    }
}
