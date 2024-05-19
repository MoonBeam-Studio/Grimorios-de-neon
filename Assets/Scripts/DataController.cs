using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour
{
    public static DataController Instance { get; private set; }
    public DataToSaveScriptableObject CurrentData;
    public DataToSaveScriptableObject BaseData;
    public RunTimeDataScriptableObject RuntimeData;

    private void Awake() => Instance = this;

    public void ResetData()
    {
        CurrentData = BaseData;
    }

    public void SavedToRunTime()
    {
        RuntimeData.MaxHealth = CurrentData.MaxHealth;
        RuntimeData.MaxMana = CurrentData.MaxMana;
        RuntimeData.MaxEnergy = CurrentData.MaxEnergy;
        RuntimeData.MaxUpgradeSlots = CurrentData.MaxUpgradeSlots;
        RuntimeData.EquippedUpgradesIDs = CurrentData.EquippedUpgradesIDs;
        RuntimeData.MaxHealingCharges = CurrentData.MaxHealingCharges;
        RuntimeData.LastSavePointID = CurrentData.LastSavePointID;
        RuntimeData.UnlockedArchivementsIDs = CurrentData.UnlockedArchivementsIDs;
        RuntimeData.QuestID = CurrentData.QuestID;
        RuntimeData.BossesDeffeatedID = CurrentData.BossesDeffeatedID;
    }

    public void RunTimeToSaved()
    {
        CurrentData.MaxHealth = RuntimeData.MaxHealth;
        CurrentData.MaxMana = RuntimeData.MaxMana;
        CurrentData.MaxEnergy = RuntimeData.MaxEnergy;
        CurrentData.MaxUpgradeSlots = RuntimeData.MaxUpgradeSlots;
        CurrentData.EquippedUpgradesIDs = RuntimeData.EquippedUpgradesIDs;
        CurrentData.MaxHealingCharges = RuntimeData.MaxHealingCharges;
        CurrentData.LastSavePointID = RuntimeData.LastSavePointID;
        CurrentData.UnlockedArchivementsIDs = RuntimeData.UnlockedArchivementsIDs;
        CurrentData.QuestID = RuntimeData.QuestID;
        CurrentData.BossesDeffeatedID = RuntimeData.BossesDeffeatedID;

        CurrentData.IsNewGame = false;
    }
}
