using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTestHitbox : PlayerHitbox
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
            /*
            GameObject damageEffect = Instantiate(Resources.Load("Prefabs/FireDamage")) as GameObject;
            if (mark.GetComponent<Mark>().isFacingRight)
            {
                damageEffect.transform.position = new Vector3(transform.position.x + 5.5f, transform.position.y + 1, -1.5f);
                
            }
            else
            {
                damageEffect.transform.position = new Vector3(transform.position.x - 5.5f, transform.position.y + 1, -1.5f);
                damageEffect.GetComponent<SpriteRenderer>().flipX = true;
            }*/
            StartCoroutine(generalManager.GetComponent<EventIssuer>().ShakeScreenDuringGameplay(0.4f, 0.05f));
        }
        base.OnTriggerEnter2D(c);
    }
}
