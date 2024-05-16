using MEET_AND_TALK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BegginingDialogue : MonoBehaviour
{
    [SerializeField] DialogueContainerSO Dialogue;
    [SerializeField] private DialogueManager DialogueManager;


    private void Start()
    {
            DialogueManager.StartDialogue(Dialogue);
    }
}
