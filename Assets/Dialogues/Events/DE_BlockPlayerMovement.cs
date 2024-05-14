using MEET_AND_TALK;
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/Events/BlockPlayerMovement")]
[System.Serializable]
public class DE_BlockPlayerMovement : DialogueEventSO
{
    private GameObject Global;
    private GlobalVariables globalVariables;
    private MonoBehaviour monoBehaviour;
    private GameObject Player;
    private ThirdPersonController characterController;
    private bool IsBloked;

    public override void RunEvent()
    {
        Global = GameObject.Find("Global");
        globalVariables = Global.GetComponent<GlobalVariables>();

        Player = globalVariables.Player;
        characterController = Player.GetComponent<ThirdPersonController>();



        if (characterController.enabled)
        {
            characterController.enabled = false;
        }
        else
        {
            characterController.enabled = true;

        }
    }
}
