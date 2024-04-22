using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NormalCamera : MonoBehaviour
{
    [SerializeField] private bool IsCameraActive = true;
    private CinemachineVirtualCamera _camera;

    private void Awake()
    {
        _camera = GetComponent<CinemachineVirtualCamera>();
    }

    private void OnEnable()
    {
        EventManager.Instance.OnCameraSwich += SwichCamera;
    }
    private void OnDisable()
    {
        EventManager.Instance.OnCameraSwich -= SwichCamera;
    }

    private void SwichCamera()
    {
        Debug.Log("Swich Camera! - Camera");
        if (IsCameraActive)
        {
            IsCameraActive = false;
            _camera.Priority = 0;
        }
        else
        {
            IsCameraActive = true;
            _camera.Priority = 2;
        }
    }
}
