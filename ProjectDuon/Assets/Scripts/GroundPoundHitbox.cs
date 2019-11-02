using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPoundHitbox : PlayerHitbox
{
    GameObject generalManager;
    AudioSource audioSource;
    GameObject mark;

    // Use this for initialization
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        mark = GameObject.Find("Mark");
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

            StartCoroutine(generalManager.GetComponent<EventIssuer>().ShakeScreenDuringGameplay(0.4f, 0.05f));
        }
        base.OnTriggerEnter2D(c);
    }
}
