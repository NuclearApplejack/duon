using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueEvent : GameplayEvent {

    public string dialogueFileName;


    public DialogueEvent(string dialogueFileName)
    {
        this.dialogueFileName = dialogueFileName;
        requiresTimedActions = false;
    }

    public override IEnumerator ExecuteEvent()
    {
        GameObject.Find("GeneralManager").GetComponent<DialogueManager>().QueueDialogueFile(dialogueFileName);
        return null;
    }
}
