using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RipAndTearShowcase : MonoBehaviour
{
    [SerializeField] List<GameObject> Enemies;
    QuestController QuestController;

    public void Count(GameObject Enemy) 
    {
        Enemies.Remove(Enemy);
    }

    private void Start()
    {
        QuestController = GetComponent<QuestController>();
    }

    private void Update()
    {
        if (Enemies.Count == 0)
        {
            //QuestController.UpdateQuest();
            RipAndTearShowcase ripAndTearShowcase = GetComponent<RipAndTearShowcase>();
            ripAndTearShowcase.enabled = false;
            GetComponent<SceneChanger>().ChangeScene();
        }
    }
}
