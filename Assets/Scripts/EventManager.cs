using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance { get; private set; }
    private void Awake() {Instance = this;}

    public delegate void CameraSwich();
    public event CameraSwich OnCameraSwich;
    public void SwitchCameraEvent()
    {
        Debug.Log("Swich Camera! - EM");
        OnCameraSwich?.Invoke();
    }

}
