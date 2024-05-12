using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAim : MonoBehaviour
{
    [SerializeField] GameObject AimGameObject;
    [SerializeField] float MoveSpeed, SprintSpeed, RotationSmoothTime;
    private ThirdPersonController ThirdPersonController;
    private bool IsShowingAim;

    private void Awake()
    {
        ThirdPersonController = GetComponent<ThirdPersonController>();
        MoveSpeed = ThirdPersonController.MoveSpeed;
        SprintSpeed = ThirdPersonController.SprintSpeed;
        RotationSmoothTime = ThirdPersonController.RotationSmoothTime;
    }

    private void OnEnable()
    {
        EventManager.Instance.OnShowAim += ShowAimGameObject;
    }

    private void OnDisable()
    {
        EventManager.Instance.OnShowAim -= ShowAimGameObject;
    }

    private void Update()
    {
        if (IsShowingAim)
        {
            ThirdPersonController.MoveSpeed = MoveSpeed/5;
            ThirdPersonController.SprintSpeed = SprintSpeed/5;
            ThirdPersonController.RotationSmoothTime = .2f;
        }
        else
        {
            ThirdPersonController.MoveSpeed = MoveSpeed;
            ThirdPersonController.SprintSpeed = SprintSpeed;
            ThirdPersonController.RotationSmoothTime= RotationSmoothTime;
        }
    }

    private void ShowAimGameObject()
    {
        if (AimGameObject.active == true)
        {
            AimGameObject.SetActive(false);
            IsShowingAim = false;
        }
        else
        {
            AimGameObject.SetActive(true);
            IsShowingAim = true;
        }
    }

}
