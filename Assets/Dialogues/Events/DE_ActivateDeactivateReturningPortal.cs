using MEET_AND_TALK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/Events/ActivateDeactivateReturningPortal")]
[System.Serializable]
public class DE_ActivateDeactivateReturningPortal : DialogueEventSO
{
    private GameObject Global, ReturningPortal;
    private GlobalVariables globalVariables;

    public override void RunEvent()
    {
        Global = GameObject.Find("Global");
        GlobalVariables globalVariables = Global.GetComponent<GlobalVariables>();
        ReturningPortal = globalVariables.PortalOniric;
        TeleportToRealWorld teleportToRealWorld = ReturningPortal.GetComponent<TeleportToRealWorld>();
        SphereCollider collider = ReturningPortal.GetComponent<SphereCollider>();

        teleportToRealWorld.enabled = !teleportToRealWorld.enabled;
        collider.enabled = !collider.enabled;
    }
}
