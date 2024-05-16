using MEET_AND_TALK;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InteractHub : MonoBehaviour
{
    [SerializeField] GameObject TextGameObject;
    [SerializeField] TextMeshProUGUI Text;
    [SerializeField] Image Image;
    [SerializeField] string MessageToDisplay;

    private void OnTriggerEnter(Collider other)
    {
        DisplayMessage(other);
    }

    private void OnTriggerExit(Collider other)
    {
        DisplayMessage(other);
    }

    public void DisplayMessage(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Text.text = MessageToDisplay;
            TextGameObject.SetActive(!TextGameObject.activeSelf);
        }
    }

    public void DisplayMessage()
    {
        Text.text = MessageToDisplay;
        Debug.Log(!TextGameObject.activeSelf);
        TextGameObject.SetActive(!TextGameObject.activeSelf);
    }
}
