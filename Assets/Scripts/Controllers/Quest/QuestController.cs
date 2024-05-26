using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuestController : MonoBehaviour
{
    [SerializeField] RunTimeDataScriptableObject runTimeData;
    [SerializeField] string NPCName;
    [SerializeField] int QuestID;
    [SerializeField, Range(0, 99)] int Progress;

    [Space]
    [SerializeField] string Quest;

    private NPCDictionary NPCDictionary;
    private string _npcName, _questID, _progress;

    private void Start()
    {
        _npcName = NPCNameFormating(NPCName);
        _questID = QuestIDFormatting(QuestID);
        _progress = ProgressFormatting(Progress);

        Quest = _npcName + _questID + _progress;
    }

    public void UpdateQuest() => runTimeData.QuestID.Add(Quest);

    private string NPCNameFormating(string name)
    {
        if (!NPCDictionary.Instance.NPCs.ContainsValue(name))
        {
            Debug.LogError($"NPC Name:{name} is not registered");
            return null;
        }

        int npcID = NPCDictionary.Instance.NPCs.FirstOrDefault(x => x.Value == name).Key;

        string nameToFormat = npcID.ToString();

        while (nameToFormat.Length < 3) nameToFormat = "0" + nameToFormat;
        Debug.Log(nameToFormat);
        return nameToFormat;
    }

    private string QuestIDFormatting(int quest)
    {
        string questToFormat = quest.ToString();

        while(questToFormat.Length < 2) questToFormat = "0" + questToFormat;

        return questToFormat;
    }

    private string ProgressFormatting(int progress)
    {
        string progressToFormat = progress.ToString();

        while (progressToFormat.Length < 2) progressToFormat = "0" + progressToFormat;

        return progressToFormat;
    }

}
