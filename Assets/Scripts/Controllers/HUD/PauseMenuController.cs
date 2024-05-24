using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField] GameObject PauseMenu;
    SceneChanger changer;

    private void Start()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1.0f;

        changer = GetComponent<SceneChanger>();
    }



    public void OpenMenu()
    {
        Cursor.lockState = CursorLockMode.Confined;
        PauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void CloseMenu()
    {
        PauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1.0f;
    }

    public void GoMainMenu()
    {
        PauseMenu.SetActive(false);

        DataController.Instance.RunTimeToSaved();
        changer.ChangeScene();
    }
}
