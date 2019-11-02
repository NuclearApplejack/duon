using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLabZPlatform : MonoBehaviour {

    bool playerIsClose = false;
    bool locationReached = false;

    float targetYPosition = 9.125f;
    float x;

    GameObject luna;

	// Use this for initialization
	void Start () {
        x = transform.position.x;
        luna = GameObject.Find("Luna");
	}
	
	// Update is called once per frame
	void Update () {
        if (luna.transform.position.x > x - 3f && luna.transform.position.x < x + 3f)
        {
            playerIsClose = true;
        }
        else
        {
            playerIsClose = false;
        }

        if (!playerIsClose)
        {
            if (transform.position.y == targetYPosition && !locationReached)
            {
                locationReached = true;
                StartCoroutine(WaitForNextAction());
                
            }
        }
        else
        {
            targetYPosition = -2f;
        }


        if (playerIsClose)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(x, targetYPosition, transform.position.z), 0.3f);
        }
        else if (!locationReached)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(x, targetYPosition, transform.position.z), 0.2f);
        }
	}

    IEnumerator WaitForNextAction()
    {

        yield return new WaitForSeconds(0.04f);
        transform.Translate(new Vector3(0, 0.25f, 0));
        yield return new WaitForSeconds(0.04f);
        transform.Translate(new Vector3(0, -0.25f, 0));
        yield return new WaitForSeconds(0.04f);
        transform.Translate(new Vector3(0, 0.125f, 0));
        yield return new WaitForSeconds(0.04f);
        transform.Translate(new Vector3(0, -0.125f, 0));
        yield return new WaitForSeconds(Random.Range(3f, 6f));
        targetYPosition = Random.Range(-2f, 20f);
        locationReached = false;
    }
}
