using MEET_AND_TALK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggerdialogue : MonoBehaviour
{
    [SerializeField] DialogueContainerSO Dialogue;
    [SerializeField] private DialogueManager DialogueManager;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DialogueManager.StartDialogue(Dialogue);
        }
    }
}
