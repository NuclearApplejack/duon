using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour {
    SceneTransitioner t;

	// Use this for initialization
	void Start () {
        t = GetComponent<SceneTransitioner>();

    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Return))
        {
            t.TransitionWithFade("MainLab", new Color(0, 0, 0));
            //SceneManager.LoadScene("Stage1Boss");
        }
	}
}
