using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueImage { 

    public DialogueImagePosition position;
    public Sprite sprite;
    public bool disabled = false;

	
    public DialogueImage(Sprite spriteSetter, DialogueImagePosition positionSetter, bool disableSetter = false)
    {
        sprite = spriteSetter;
        position = positionSetter;
        disabled = disableSetter;
    }
}
