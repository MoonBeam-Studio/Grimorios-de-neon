using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ArchivementTranslator : MonoBehaviour
{
    public static ArchivementTranslator Instance { get; private set; }

    private void Awake() => Instance = this;

    public ArchivementCategory GetArchivementCategory(string ArchivementID)
    {
        ArchivementCategory category = ArchivementCategory.Ability;
        int CategoryID = ArchivementID[0] - '0';

        switch (CategoryID)
        {
            case 0:
                category = ArchivementCategory.Ability;
                break;
            case 1:
                category = ArchivementCategory.Upgrade;
                break;
            case 2:
                category = ArchivementCategory.Archivement;
                break;
        }
        return category;
    }
}
