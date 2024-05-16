using MEET_AND_TALK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToRealWorld : InteractuableObject
{
    public override void Interact()
    {
        SceneChanger sceneChanger = gameObject.GetComponent<SceneChanger>();

        sceneChanger.ChangeScene();
    }
}