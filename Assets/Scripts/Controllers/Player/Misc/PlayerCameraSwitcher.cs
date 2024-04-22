using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraSwitcher : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) SwitchCamera();
    }

    private void SwitchCamera()
    {
        Debug.Log("Swich Camera! - Player");
        EventManager.Instance.SwitchCameraEvent();
    }
}
