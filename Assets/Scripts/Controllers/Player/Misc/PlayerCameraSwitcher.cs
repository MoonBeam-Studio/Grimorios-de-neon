using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraSwitcher : MonoBehaviour
{
    private void SwitchCamera()
    {
        EventManager.Instance.SwitchCameraEvent();
    }
}
