using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RipAndTearQuest : QuestDetector
{
    [SerializeField] RunTimeDataScriptableObject RunTimeData;
    [SerializeField] string Quest;
    [SerializeField] Transform PointToSpawn, Player;

    private void Start()
    {
        if(!CheckQuestInData(Quest,RunTimeData)) return;

        Player.position = PointToSpawn.position;
    }
}
