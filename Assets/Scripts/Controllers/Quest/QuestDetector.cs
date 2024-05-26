using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestDetector : MonoBehaviour
{
    public bool CheckQuestInData(string quest, RunTimeDataScriptableObject runTimeData)
    {
        bool Contained = runTimeData.QuestID.Contains(quest);
        return Contained;
    }
}
