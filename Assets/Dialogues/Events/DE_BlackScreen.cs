using MEET_AND_TALK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Dialogue/Events/BlackScreen")]
[System.Serializable]
public class DE_BlackScreen : DialogueEventSO
{
    [SerializeField] int ChangeStep;
    [SerializeField] bool IsOpaque;
    private GameObject _blackScreenGameObject;
    private Animator _blackScreenAnimator;
    private GameObject Global;
    private MonoBehaviour monoBehaviour;

    public override void RunEvent()
    {
        Global = GameObject.Find("Global");
        monoBehaviour = Global.GetComponent<MonoBehaviour>();
        GlobalVariables globalVariables = Global.GetComponent<GlobalVariables>();
        GameObject _blackScreenGameObject = globalVariables.BlackScreen;
        _blackScreenAnimator = _blackScreenGameObject.GetComponent<Animator>();
        IsOpaque = _blackScreenGameObject.activeSelf;

        if (IsOpaque)
        {
            _blackScreenAnimator.SetTrigger("FadeIn");
            IsOpaque = false;
        }
        else
        {
            _blackScreenAnimator.SetTrigger("FadeOut");
            IsOpaque = true;
        }
    }
}
