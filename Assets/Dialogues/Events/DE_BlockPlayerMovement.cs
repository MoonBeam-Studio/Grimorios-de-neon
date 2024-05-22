using MEET_AND_TALK;
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Dialogue/Events/BlockPlayerMovement")]
[System.Serializable]
public class DE_BlockPlayerMovement : DialogueEventSO
{
    private GameObject Global;
    private GlobalVariables globalVariables;
    private MonoBehaviour monoBehaviour;
    private GameObject Player;
    private ThirdPersonController characterController;
    private PlayerInput playerInput;
    private bool IsBloked;

    public override void RunEvent()
    {
        Global = GameObject.Find("Global");
        globalVariables = Global.GetComponent<GlobalVariables>();

        Player = globalVariables.Player;
        characterController = Player.GetComponent<ThirdPersonController>();
        playerInput = Player.GetComponent<PlayerInput>();



        if (characterController.enabled)
        {
            characterController.enabled = false;
            playerInput.SwitchCurrentActionMap("InDialogue");
            Debug.Log(playerInput.currentActionMap);
        }
        else
        {
            characterController.enabled = true;
            playerInput.SwitchCurrentActionMap("Player");
            Debug.Log(playerInput.currentActionMap);
        }
    }
}
