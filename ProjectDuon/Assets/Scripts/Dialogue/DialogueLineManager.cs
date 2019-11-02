using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueLineManager : MonoBehaviour {

    public bool textIsDone = false;
    public string text = "";
    string originalText;

    GameObject generalManager;

    string currentlyShownText = "";
    public float textSpeedPerChar = 0.01f;
    float currentCharDelay = 0;

    //public string speaker = "";

    Text textComponent;

	// Use this for initialization
	void Start () {
        textComponent = GetComponent<Text>();
        originalText = text;
        generalManager = GameObject.Find("GeneralManager");
    }
	
	// Update is called once per frame
	void Update () {
        if (currentlyShownText.Equals(originalText))
        {
            textIsDone = true;
            
        }
        else
        {
            textIsDone = false;
        }


        if (textIsDone)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
            {
                generalManager.GetComponent<DialogueManager>().dialogueIsOn = false;
                /*
                Destroy(GameObject.Find("SpeakerText"));
                Destroy(gameObject);
                */
                textComponent.text = "";
                Destroy(this);

            }
        }
        else
        {
            

            if (currentCharDelay >= textSpeedPerChar)
            {
                currentCharDelay = 0;
                currentlyShownText += text[0];
                text = text.Substring(1);
            }
            else
            {
                currentCharDelay += Time.deltaTime;
            }

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
            {
                textIsDone = true;
                currentlyShownText = originalText;
            }
        }

        textComponent.text = currentlyShownText;
	}

    
}
