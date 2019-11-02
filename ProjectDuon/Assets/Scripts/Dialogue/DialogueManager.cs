using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.IO;
using System;

public class DialogueManager : MonoBehaviour{



    public GameObject targetCanvas;
    public Font font;

    Sprite dialogueBGSprite;
    Sprite dialogueBGSpriteSpeakerless;

    public GameObject topRightSprite;
    public GameObject topLeftSprite;
    public GameObject bottomRightSprite;
    public GameObject bottomLeftSprite;

    public GameObject speakerText;
    public GameObject dialogueText;

    public bool dialogueIsOn = false;
    public bool dialogueSequenceIsOn = false;

    public List<DialogueLine> dialogueQueue = new List<DialogueLine>();

    GameObject textBG;




    void Start()
    {
        speakerText = GameObject.Find("SpeakerText");
        dialogueText = GameObject.Find("DialogueText");
        dialogueBGSprite = Resources.Load<Sprite>("Graphics/UI/Dialogue Sprites/dialogue temp cropped 2") as Sprite;
        dialogueBGSpriteSpeakerless = Resources.Load<Sprite>("Graphics/UI/Dialogue Sprites/dialogue temp cropped 2 speakerless") as Sprite;

        textBG = new GameObject("DialogueBG");
        Image dialogueBG = textBG.AddComponent<Image>();
        textBG.transform.SetParent(targetCanvas.transform.Find("DialoguePanel"));
        dialogueBG.sprite = null;
        dialogueBG.color = new Color(1, 1, 1, 0);
        textBG.GetComponent<RectTransform>().pivot = new Vector2(0, 0);
        textBG.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0);
        textBG.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0);
        textBG.GetComponent<RectTransform>().anchoredPosition = new Vector2(-316, -126);
        textBG.GetComponent<RectTransform>().sizeDelta = new Vector2(632 * UITools.GetUIScalingFactor(), 104 * UITools.GetUIScalingFactor());

    }

    void Update()
    {
        

        if (dialogueQueue.Count != 0)
        {
            dialogueSequenceIsOn = true;

            if (dialogueQueue[0].speaker == null || dialogueQueue[0].speaker.Trim() == "")
            {
                textBG.GetComponent<Image>().sprite = dialogueBGSpriteSpeakerless;
            }
            else
            {
                textBG.GetComponent<Image>().sprite = dialogueBGSprite;
            }

            textBG.GetComponent<Image>().color = new Color(1, 1, 1, 1);

            targetCanvas.SetActive(true);

            if (!dialogueIsOn)
            {
                GenerateDialogueLine(dialogueQueue[0]);
                dialogueQueue.RemoveAt(0);
            }
        }
        else if (!dialogueIsOn)
        {
            dialogueSequenceIsOn = false;
            topRightSprite.GetComponent<Image>().sprite = null;
            topLeftSprite.GetComponent<Image>().sprite = null;
            bottomRightSprite.GetComponent<Image>().sprite = null;
            bottomLeftSprite.GetComponent<Image>().sprite = null;

            bottomLeftSprite.GetComponent<Image>().color = new Color(1, 1, 1, 0);
            bottomRightSprite.GetComponent<Image>().color = new Color(1, 1, 1, 0);
            topLeftSprite.GetComponent<Image>().color = new Color(1, 1, 1, 0);
            topRightSprite.GetComponent<Image>().color = new Color(1, 1, 1, 0);

            textBG.GetComponent<Image>().sprite = null;
            textBG.GetComponent<Image>().color = new Color(1, 1, 1, 0);

            speakerText.GetComponent<Text>().text = "";
            dialogueText.GetComponent<Text>().text = "";
        }

        

    }

    public void GenerateDialogue(List<DialogueLine> dialogueLines)
    {
        dialogueQueue.AddRange(dialogueLines);
    }

    public void GenerateDialogueLine(DialogueLine line)
    {
        dialogueIsOn = true;

        if (line.dialogueImages != null && line.dialogueImages.Count > 0) {
            foreach (DialogueImage image in line.dialogueImages)
            {
                if (image.sprite != null)
                {
                    if (image.position == DialogueImagePosition.BOTTOM_LEFT)
                    {
                        bottomLeftSprite.GetComponent<Image>().sprite = image.sprite;
                        if (!image.disabled)
                        {
                            bottomLeftSprite.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                        }
                        else
                        {
                            bottomLeftSprite.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1);
                        }
                    }
                    else if (image.position == DialogueImagePosition.BOTTOM_RIGHT)
                    {
                        bottomRightSprite.GetComponent<Image>().sprite = image.sprite;
                        if (!image.disabled)
                        {
                            bottomRightSprite.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                        }
                        else
                        {
                            bottomRightSprite.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1);
                        }
                    }
                    else if (image.position == DialogueImagePosition.TOP_LEFT)
                    {
                        topLeftSprite.GetComponent<Image>().sprite = image.sprite;
                        if (!image.disabled)
                        {
                            topLeftSprite.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                        }
                        else
                        {
                            topLeftSprite.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1);
                        }
                    }
                    else
                    {
                        topRightSprite.GetComponent<Image>().sprite = image.sprite;
                        if (!image.disabled)
                        {
                            topRightSprite.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                        }
                        else
                        {
                            topRightSprite.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1);
                        }
                    }
                }
                else
                {
                    if (image.position == DialogueImagePosition.BOTTOM_LEFT)
                    {
                        bottomLeftSprite.GetComponent<Image>().sprite = null;
                        bottomLeftSprite.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                    }
                    else if (image.position == DialogueImagePosition.BOTTOM_RIGHT)
                    {
                        bottomRightSprite.GetComponent<Image>().sprite = null;
                        bottomRightSprite.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                    }
                    else if (image.position == DialogueImagePosition.TOP_LEFT)
                    {
                        topLeftSprite.GetComponent<Image>().sprite = null;
                        topLeftSprite.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                    }
                    else
                    {
                        topRightSprite.GetComponent<Image>().sprite = null;
                        topRightSprite.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                    }
                }
            }

        }
        /*
        GameObject speakerHolder = new GameObject("SpeakerText");
        speakerHolder.transform.SetParent(targetCanvas.transform);

        Text name = speakerHolder.AddComponent<Text>();
        name.text = line.speaker;
        speakerHolder.GetComponent<RectTransform>().pivot = new Vector2(0, 0);
        speakerHolder.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0);
        speakerHolder.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0);
        speakerHolder.GetComponent<RectTransform>().anchoredPosition = new Vector2(-300, 36.5f);
        speakerHolder.GetComponent<RectTransform>().sizeDelta = new Vector2(612 * UITools.GetUIScalingFactor(), 66 * UITools.GetUIScalingFactor());
        name.fontSize = 24;
        name.font = font;

        GameObject textHolder = new GameObject("DialogueText");
        textHolder.transform.SetParent(targetCanvas.transform);

        
        Text text = textHolder.AddComponent<Text>();
        textHolder.AddComponent<DialogueLineManager>().text = line.text;
        textHolder.GetComponent<DialogueLineManager>().textSpeedPerChar = line.charSpeed;
        textHolder.GetComponent<RectTransform>().pivot = new Vector2(0, 0);
        textHolder.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0);
        textHolder.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0);
        textHolder.GetComponent<RectTransform>().anchoredPosition = new Vector2(-306, 14);
        textHolder.GetComponent<RectTransform>().sizeDelta = new Vector2(612 * UITools.GetUIScalingFactor(), 66 * UITools.GetUIScalingFactor());
        textHolder.GetComponent<Text>().lineSpacing = 1.2f;
        text.fontSize = 24;
        text.font = font;
        */

        speakerText.GetComponent<Text>().text = line.speaker;

        dialogueText.AddComponent<DialogueLineManager>().text = line.text;
        dialogueText.GetComponent<DialogueLineManager>().textSpeedPerChar = line.charSpeed;

    }

    public void QueueDialogueFile(string fileName)
    {
        dialogueSequenceIsOn = true;

        List<DialogueLine> lines = new List<DialogueLine>();
        
        TextAsset textFile = Resources.Load("Text Files/" + fileName) as TextAsset;

        
        string currentText = textFile.text;

        while (currentText.Trim() != "")
        {
            string line = currentText.Substring(0, currentText.IndexOf('\n'));
            if (line != null && line.Length > 1 && line.Substring(0, 2) != "//")
            {
                lines.Add(StringToDialogueLine(line));
            }
            currentText = currentText.Remove(0, currentText.IndexOf('\n') + 1);
        }
        

        GenerateDialogue(lines);
    }

    public DialogueLine StringToDialogueLine(string rawText)
    {
        string lineText = "";
        string speaker = null;
        float speed = 0.01f;
        List<DialogueImage> images = new List<DialogueImage>();


        while (rawText.Length > 0)
        {
            rawText = rawText.Trim();

            
            if (rawText[0] == '@')
            {
                rawText = rawText.Remove(0, 1);
                lineText = rawText;
                break;
            }
            else if (rawText[0] == '[')
            {
                rawText = rawText.Remove(0, 1);
                speaker = rawText.Substring(0, rawText.IndexOf(']'));
                rawText = rawText.Remove(0, rawText.IndexOf(']'));
            }
            else if (rawText[0] == '{')
            {
                rawText = rawText.Remove(0, 1);
                speed = float.Parse(rawText.Substring(0, rawText.IndexOf('}')));
                rawText = rawText.Remove(0, rawText.IndexOf('}'));
            }
            else if (rawText[0] == '(')
            {
                rawText = rawText.Remove(0, 1);

                Sprite sprite;
                if (rawText.Substring(0, rawText.IndexOf(',')).ToUpper() == "NONE")
                {
                    sprite = null;
                }
                else
                {
                    sprite = Resources.Load("Graphics/UI/Dialogue Sprites/" + rawText.Substring(0, rawText.IndexOf(',')), typeof(Sprite)) as Sprite;
                }
                


                rawText = rawText.Remove(0, rawText.IndexOf(',') + 1);
                rawText = rawText.Trim();

                DialogueImagePosition position = (DialogueImagePosition)Enum.Parse(typeof(DialogueImagePosition), rawText.Substring(0, rawText.IndexOf(',')));

                rawText = rawText.Remove(0, rawText.IndexOf(',') + 1);
                rawText = rawText.Trim();

                bool disabled = false;
                if (rawText.Substring(0, rawText.IndexOf(')')).ToUpper() == "D") {
                    disabled = true;
                }

                images.Add(new DialogueImage(sprite, position, disabled));
                rawText = rawText.Remove(0, rawText.IndexOf(')'));
            }
            else
            {
                rawText = rawText.Remove(0, 1);
            }
        }


        return new DialogueLine(lineText, speaker, speed, images);
    }
}


