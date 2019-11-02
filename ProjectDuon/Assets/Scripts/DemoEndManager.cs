using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DemoEndManager : MonoBehaviour {

    GameObject manager;
    public AudioClip audioClip;
    public Image bg;
    public List<MaskableGraphic> texts = new List<MaskableGraphic>();

    bool clear = false;
    bool audioPlayed = false;
    float timer = 0f;

	// Use this for initialization
	void Start () {
        manager = GameObject.Find("Manager");
	}
	
	// Update is called once per frame
	void Update () {
        if (clear)
        {

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
            {
                manager.GetComponent<SceneTransitioner>().TransitionWithFade("MainLab", Color.black);
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                manager.GetComponent<SceneTransitioner>().TransitionWithFade("TitleScreen", Color.black);
            }
        }
        else
        {
            timer += Time.deltaTime;

            bg.color = new Color(1, 1, 1, Mathf.Min(Mathf.Max((timer - 2) / 2f, 0f), 1f));

            if (timer >= 2f && !audioPlayed)
            {
                GetComponent<AudioSource>().PlayOneShot(audioClip);
                audioPlayed = true;
            }

            foreach (MaskableGraphic text in texts)
            {
                if (text.gameObject.name == "Black")
                {
                    text.color = new Color(0, 0, 0, Mathf.Min(Mathf.Max((timer - 8) / 2f, 0f), 1f) * 0.8f);
                }
                else
                {
                    text.color = new Color(1, 1, 1, Mathf.Min(Mathf.Max((timer - 8) / 2f, 0f), 1f));
                }
                
            }

            if (timer > 12f)
            {
                clear = true;
            }
        }
    }
}
