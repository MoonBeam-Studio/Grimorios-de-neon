using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneChanger : MonoBehaviour
{
    [SerializeField] string SceneName;

    private Scene Scene;

    private void Start()
    {
        Scene = SceneManager.GetSceneByName(SceneName);
    }

    public void ChangeScene()
    {
        SceneManager.LoadSceneAsync(SceneName);
        //Debug.Log(SceneName);
    }
}
