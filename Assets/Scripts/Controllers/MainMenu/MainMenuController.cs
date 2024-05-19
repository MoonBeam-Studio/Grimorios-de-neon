using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }

    public void NewGame()
    {
        DataController.Instance.ResetData();
        SceneManager.LoadSceneAsync("NewBeginning");
    }

    public void ContinueGame()
    {
        if (!DataController.Instance.CurrentData.IsNewGame)
        {
            string SceneToCharge = SceneGetter.Instance.GetSceneByID(DataController.Instance.CurrentData.LastSavePointID.Remove(DataController.Instance.CurrentData.LastSavePointID.Length - 1));
            DataController.Instance.SavedToRunTime();
            SceneManager.LoadSceneAsync(SceneToCharge);
        }


        Debug.Log("Continue Game");
    }
}
