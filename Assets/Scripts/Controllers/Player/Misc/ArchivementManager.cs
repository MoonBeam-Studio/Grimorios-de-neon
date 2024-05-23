using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class ArchivementManager : MonoBehaviour
{
    [SerializeField] RunTimeDataScriptableObject RunTimeData;

    [Space, Header("Abilties")]
    [SerializeField] int[] AbiltyId;
    [SerializeField] string[] AbiltyName;

    Dictionary<int, string> Abilities = new Dictionary<int, string>();


    [Space,Header("Upgrades")]
    [SerializeField] int[] UpgradeId;
    [SerializeField] string[] UpgradeName;

    Dictionary<int, string> Upgrades = new Dictionary<int, string>();

    [Space,Header("Archivements")]
    [SerializeField] int[] ArchivementId;
    [SerializeField] string[] ArchivementName;

    Dictionary<int, string> Archivements = new Dictionary<int, string>();

    private void Start()
    {
        foreach (int ID in AbiltyId)
        {
            Abilities.Add(ID, AbiltyName[ID]);
        }

        foreach (int ID in UpgradeId)
        {
            Upgrades.Add(ID, UpgradeName[ID]);
        }

        foreach (int ID in ArchivementId)
        {
            Archivements.Add(ID, ArchivementName[ID]);
        }
    }

    private void Update()
    {
        foreach (string ArchivementID in RunTimeData.UnlockedArchivementsIDs)
        {
            switch (ArchivementTranslator.Instance.GetArchivementCategory(ArchivementID))
            {
                case ArchivementCategory.Ability:
                    AbiltyManager(ConvertToID(ArchivementID));
                    break;
                case ArchivementCategory.Upgrade:
                    //
                    break;
                case ArchivementCategory.Archivement:
                    //
                    break;
                default:
                    continue;
            }
        }
    }

    private int ConvertToID(string ArchivementID)
    {
        ArchivementID = ArchivementID.TrimStart();
        int ID;

        if (int.TryParse(ArchivementID, out ID))
        {
            return ID;
        }
        else return 0;
    }
    
    private void AbiltyManager(int AbilityId)
    {
        //if(!Abilities.ContainsKey(AbilityId)) return;

        string Ability = Abilities[AbilityId];

        switch (Ability) 
        {
            case "Glich":
                gameObject.GetComponent<PlayerGlich>().enabled = true;
                break;
            case "RipAndTear":
                gameObject.GetComponent<RipAndTear>().enabled = true;
                gameObject.GetComponent<ShowAim>().enabled = true;
                break;
        }
    }
}
