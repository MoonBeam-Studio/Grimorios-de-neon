using MEET_AND_TALK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/Events/ShowInteractIndicator")]
[System.Serializable]
public class DE_ShowInteractIndicator : DialogueEventSO
{
    private GameObject Global;
    private MonoBehaviour monoBehaviour;
    private GlobalVariables GlobalVariables;

    public override void RunEvent()
    {
        Global = GameObject.Find("Global");
        GlobalVariables = Global.GetComponent<GlobalVariables>();
        monoBehaviour = Global.GetComponent<MonoBehaviour>();

        monoBehaviour.StartCoroutine(ShowInteractIndicator(GlobalVariables.TextHUB));
    }

    IEnumerator ShowInteractIndicator(GameObject InteractIndicator)
    {
        yield return new WaitForSeconds(.5f);
        InteractIndicator.SetActive(!InteractIndicator.activeSelf);
    }
}
