using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitbox : MonoBehaviour {

    public int damage;
    public Vector2 knockback;
    public AudioClip soundEffect;

    public List<GameObject> enemiesHit;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag == "EnemyHurtbox")
        {
            c.transform.parent.gameObject.GetComponent<GeneralEnemy>().TakeDamage(damage);
            enemiesHit.Add(c.transform.parent.gameObject);
        }
    }
}
