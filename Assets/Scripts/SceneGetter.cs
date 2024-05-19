using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneGetter : MonoBehaviour
{
    public static SceneGetter Instance { get; private set; }
    private void Awake() => Instance = this;

    public Dictionary<int, string> Zones = new Dictionary<int, string>();
    public int[] ZoneID;
    public string[] ZoneName;

    private void Start()
    {
        foreach (int ID in ZoneID)
        {
            Zones.Add(ID, ZoneName[ID]);
        }
    }

    public string GetSceneByID(string SceneID)
    {
        string sceneID = SceneID[SceneID.Length - 1].ToString();
        string zoneID = SceneID.Remove(SceneID.Length - 1);

        Zones.TryGetValue(int.Parse(zoneID), out string ZoneName);

        return (ZoneName + sceneID);
    }
}