using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ArchivementRevoker : MonoBehaviour
{
    [SerializeField] RunTimeDataScriptableObject runTimeData;
    [SerializeField] int ArchivementID;
    [SerializeField] ArchivementCategory Category;
    [SerializeField] string Archivement;

    private void Start()
    {
        Archivement = GetID();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Player")) return;

        RevokeArchivement();
    }

    public void RevokeArchivement()
    {
        if (!runTimeData.UnlockedArchivementsIDs.Contains(Archivement))
            runTimeData.UnlockedArchivementsIDs.Remove(Archivement);
    }

    private string GetID()
    {
        string archivement = ArchivementID.ToString();
        string categoryId;

        switch (Category)
        {
            case ArchivementCategory.Ability:
                categoryId = "0";
                break;
            case ArchivementCategory.Upgrade:
                categoryId = "1";
                break;
            case ArchivementCategory.Archivement:
                categoryId = "2";
                break;
            default:
                categoryId = "0";
                break;
        }

        while(archivement.Length < 2)
        {
            archivement = "0"+archivement;
        }

        archivement = categoryId + archivement;

        return archivement;
    }
}
