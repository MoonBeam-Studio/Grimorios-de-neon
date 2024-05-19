using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="SaveData",menuName = "ScriptableObjects/Player/SaveData", order = 0)]
public class DataToSaveScriptableObject : ScriptableObject
{
    [Header("Numerical Stats of the player")]
    [Tooltip("Always a multiple of 10")] public int MaxHealth = 100;
    [Tooltip("Always a multiple of 5")] public int MaxMana = 20;
    [Tooltip("Always a multiple of 2")] public int MaxEnergy = 10;
    [Range(3,10)] public int MaxUpgradeSlots = 0;
    [Range(2, 7)]public int MaxHealingCharges = 0;

    [Header("IDs of save point")]
    [Tooltip("[AA] SceneID [BB]Savepoint ID")]public string LastSavePointID = "0000";

    [Header("IDs of unlockeables")]
    [Tooltip("[A] Category ID [BB]Unlockeable ID")] public string[] UnlockedArchivementsIDs;
    [Tooltip("[A] Category ID [BB]Unlockeable ID")] public string[] EquippedUpgradesIDs;

    [Header("IDs of Progression")]
    [Tooltip("[AA] Boss ID")]public string[] BossesDeffeatedID;
    [Tooltip("[AAA] NPC ID [BB]Quest ID [GG] Progress ID")] public string[] QuestID;

    [Space]
    public bool IsNewGame;
}
