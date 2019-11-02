using UnityEngine;
using System.Collections;

public class GroundChecker : MonoBehaviour {

    PlayableCharacter character;

    // Use this for initialization
    void Start () {
        character = gameObject.GetComponentInParent<PlayableCharacter>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Terrain"))
        {
            character.grounded = true;
            character.currTerrain = collider.gameObject.GetComponent<Terrain>().type;
        }
        
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Terrain"))
        {
            character.grounded = false;
        }
        
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.CompareTag("Terrain"))
        {
            character.grounded = true;
            character.currTerrain = collider.gameObject.GetComponent<Terrain>().type;
        }
    }
}
