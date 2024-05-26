using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RipSpearUnlockBridge : MonoBehaviour
{
    [SerializeField] List<GameObject> Pilars;
    [SerializeField] GameObject Bridge;
    QuestController questController;

    private void Awake() => questController = GetComponent<QuestController>();
    public void Count(GameObject Pilar)
    {
        Pilars.Remove(Pilar);
        GameObject PilarCenter = GameObject.Find($"{Pilar.name}/Center");
        PilarCenter.SetActive(false);
    }

    private void Update()
    {
        if (Pilars.Count == 0)
        {
            //questController.UpdateQuest();
            Bridge.SetActive(true);
        }
    }
}
