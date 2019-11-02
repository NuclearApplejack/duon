using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PulsarIntroManager : MonoBehaviour {

    public Image effect;
    float timer = 0f;

	// Use this for initialization
	void Start () {
        Cursor.visible = false;
        
        LoadingTipsHolder.PopulateList();
        LoadingTipsHolder.GenerateNewTip();
    }
	
	// Update is called once per frame
	void Update () {
        if (timer <= 1f)
        {
            effect.color = new Color(0, 0, 0, 1f - timer);
        }
        else if (timer > 6f && timer < 8f)
        {
            effect.color = new Color(0, 0, 0, Mathf.Min(timer - 6f, 1f));
        }
        else if (timer >= 8f)
        {
            SceneManager.LoadScene("TitleScreen");
        }

        timer += Time.deltaTime;

        if (Input.anyKeyDown && timer < 6f)
        {
            timer = 6f;
        }
	}


}
