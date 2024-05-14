using MEET_AND_TALK;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(menuName ="Dialogue/Events/SowAiriel")]
[System.Serializable]
public class DE_ShowAiriel : DialogueEventSO
{
    [SerializeField] float TimeToDisappear;
    private GameObject AirielUI;
    private GameObject Global;
    private MonoBehaviour monoBehaviour;
    public override void RunEvent()
    {
        Global = GameObject.Find("Global");
        monoBehaviour = Global.GetComponent<MonoBehaviour>();
        GlobalVariables globalVariables = Global.GetComponent<GlobalVariables>();
        GameObject airielHub = globalVariables.AirielHUB;

        if (airielHub.activeSelf) DimAiriel(airielHub);
        else airielHub.SetActive(true);
    }

    private void DimAiriel(GameObject _airiel)
    {
        ParticleSystem[] AirielParticleSystem = _airiel.GetComponentsInChildren<ParticleSystem>();
        foreach (ParticleSystem particle in AirielParticleSystem)
        {
            particle.startColor = Color.clear;
            monoBehaviour.StartCoroutine(TurnAirielOff(_airiel));
        }
    }

    IEnumerator TurnAirielOff(GameObject _airiel)
    {
        yield return new WaitForSeconds(TimeToDisappear);
        _airiel.SetActive(false);
    }
}
