using MEET_AND_TALK;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OniricWorldAirielTalk : InteractuableObject
{
    [SerializeField] DialogueContainerSO Dialogue;
    [SerializeField] private DialogueManager DialogueManager;

    public override void Interact()
    {
        Message();
        DialogueManager.StartDialogue(Dialogue);
    }
}
