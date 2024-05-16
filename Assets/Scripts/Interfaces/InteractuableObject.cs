using MEET_AND_TALK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class InteractuableObject : MonoBehaviour
{
    private bool InTrigger;
    private InteractHub interactHub;


    private void OnEnable()
    {
        EventManager.Instance.OnInteract += InteractPressed;
        interactHub = gameObject.GetComponent<InteractHub>();
    }

    private void OnDisable()
    {
        EventManager.Instance.OnInteract -= InteractPressed;
    }


    public void OnTriggerEnter(Collider other) => Trigger(other);
    public void OnTriggerExit(Collider other) => Trigger(other);

    public void Trigger(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InTrigger = !InTrigger;
        }
    }
    public void InteractPressed()
    {
        if (InTrigger)
        {
            Interact();
            
        }
    }
    public void Message()
    {
        interactHub.DisplayMessage();
    }

    public virtual void Interact()
    {

    }
}