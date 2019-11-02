using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class DialogueLine
{
    public string speaker = "";
    public Color speakerColor = UITools.ColorFromRGB(255, 255, 255);
    public float charSpeed = 0.01f;

    public string text = "";

    public List<DialogueImage> dialogueImages;


    public DialogueLine(string textSetter, string speakerSetter = null, float charSpeedSetter = 0.01f, List<DialogueImage> imagesSetter = null)
    {
        speaker = speakerSetter;
        text = textSetter;
        charSpeed = charSpeedSetter;
        dialogueImages = imagesSetter;
    }


}

