using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour {
    SceneTransitioner t;
    bool transitioning = false;

    // Use this for initialization
    void Start()
    {
        t = GetComponent<SceneTransitioner>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.Escape))
        {
            transitioning = true;
            Transition();
        }

        if (transitioning)
        {
            GetComponent<AudioSource>().volume -= Time.deltaTime;
        }
    }

    public void Transition()
    {
        t.TransitionWithFade("MainLab", new Color(0, 0, 0));
    }
}
