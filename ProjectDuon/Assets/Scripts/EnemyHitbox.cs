using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : MonoBehaviour {

    public int damage;
    public Vector2 knockback;
    public GameObject generalManager;

	// Use this for initialization
	void Start () {
        generalManager = GameObject.Find("GeneralManager");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay2D (Collider2D c)
    {
        if (c.tag == "PlayerHurtbox")
        {
            
            c.transform.parent.gameObject.GetComponent<PlayableCharacter>().health -= damage;
            generalManager.GetComponent<ComboManager>().EndCombo();
            if (c.transform.parent.gameObject.GetComponent<PlayableCharacter>().health < 0)
            {
                c.transform.parent.gameObject.GetComponent<PlayableCharacter>().health = 0;
            }
            c.transform.parent.gameObject.GetComponent<Rigidbody2D>().AddForce(knockback);
        }
    }
}
