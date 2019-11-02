using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour {

    SceneTransitioner t;
    float timer = 2f;

    // Use this for initialization
    void Start()
    {
        t = GetComponent<SceneTransitioner>();
        GetComponent<AudioSource>().PlayOneShot(Resources.Load<AudioClip>("Sound/SFX/Misc/Death"), 0.7f);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0f)
        {
            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Return))
            {
                t.TransitionWithFade("Stage1PreBoss", new Color(0, 0, 0));
            }
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
