using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "RunTimeData", menuName = "ScriptableObjects/Player/RunTimeData", order = 1)]
public class RunTimeDataScriptableObject : ScriptableObject
{
    [Header("Data to Store"),Space(5)]
    [Header("Numerical Stats of the player")]
    [Tooltip("Always a multiple of 10")] public int MaxHealth = 100;
    [Tooltip("Always a multiple of 5")] public int MaxMana = 20;
    [Tooltip("Always a multiple of 2")] public int MaxEnergy = 10;
    [Tooltip("Between 3-10")] public int MaxUpgradeSlots = 0;
    [Tooltip("Between 2-7")] public int MaxHealingCharges = 0;

    [Header("IDs of save point")]
    [Tooltip("[AA] SceneID [BB]Savepoint ID")] public string LastSavePointID = "0000";

    [Header("IDs of unlockeables")]
    [Tooltip("[A] Category ID [BB]Unlockeable ID")] public string[] UnlockedArchivementsIDs;
    [Tooltip("[A] Category ID [BB]Unlockeable ID")] public string[] EquippedUpgradesIDs;

    [Header("IDs of Progression")]
    [Tooltip("[AA] Boss ID")] public string[] BossesDeffeatedID;
    [Tooltip("[AAA] NPC ID [BB]Quest ID [GG] Progress ID")] public string QuestID;

    [Space(10), Header("Run Time Data"),Space(5)]

    [Header("Numerical Stats of the player")]
    [Tooltip("Always a multiple of 10")] public int CurrentHealth = 100;
    [Tooltip("Always a multiple of 5")] public int CurrentMana = 20;
    [Tooltip("Always a multiple of 2")] public int CurrentEnergy = 10;
    [Tooltip("Between 3-10")] public int CurrentUpgradeSlots = 0;
    [Tooltip("Between 2-7")] public int CurrentHealingCharges = 0;
}
