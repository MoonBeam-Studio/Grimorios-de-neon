using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDictionary : MonoBehaviour
{
    [SerializeField] List<int> NPCID;
    [SerializeField] List<string> NPCName;
    public Dictionary<int,string> NPCs = new Dictionary<int,string>();

    public static NPCDictionary Instance { get; private set; }
    private void Awake() => Instance = this;

    private void Update()
    {
        foreach (int ID in NPCID)
        {
            if (NPCs.ContainsKey(ID)) break;
            NPCs.Add(ID, NPCName[ID]);
            Debug.Log($"{NPCName[ID]}: {ID}");
        }
    }
}
