using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class TestInputSystem : MonoBehaviour
{

    private PlayerInput _PlayerInput;
    private InputAction MovementInput;
    private CharacterController _CharacterController;
    private float Gravity = -9.81f;
    private Vector3 playerSpeed;
    private Vector2 MovementInputValues;

    [SerializeField] private bool IsGrounded;
    [SerializeField] private float movementSpeed = 2f, jumpHeigh = 1f;
    [SerializeField] private Transform Camera;
    [SerializeField] private LayerMask GroundLayer;

    private void Awake()
    {
        _PlayerInput = GetComponent<PlayerInput>();
        _CharacterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        MovementInput = _PlayerInput.actions.FindAction("Movement");
    }

    private void Update()
    { 
        GroundCheck();

        if (IsGrounded && playerSpeed.y < 0) playerSpeed.y = 0;

        Debug.Log(MovementInputValues = MovementInput.ReadValue<Vector2>());

        Vector3 Movement = new Vector3(MovementInputValues.x, 0, MovementInputValues.y) * Time.deltaTime * movementSpeed;
        Debug.Log(Movement);
        _CharacterController.Move(Movement);

        if (Movement != Vector3.zero) gameObject.transform.position = Movement;

        playerSpeed.y += Time.deltaTime * Gravity;
        _CharacterController.Move(playerSpeed * Time.deltaTime);
    }

    private void LateUpdate()
    {
        CameraRotation();
    }

    private void OnMovement()
    {
    }

    private void OnJump()
    {
        if (IsGrounded)
        {
            playerSpeed.y += Mathf.Sqrt(jumpHeigh * -3 * Gravity);
        }
    }

    private void GroundCheck()
    {
        if (Physics.Raycast(transform.position, -transform.up, .5f, GroundLayer)) IsGrounded = true;
        else IsGrounded = false;
    }

    private void CameraRotation()
    {
        // if there is an input and camera position is not fixed
        if (_input.look.sqrMagnitude >= .01f)
        {
            //Don't multiply mouse input by Time.deltaTime;
            float deltaTimeMultiplier = IsCurrentDeviceMouse ? 1.0f : Time.deltaTime;

            _cinemachineTargetYaw += _input.look.x * deltaTimeMultiplier;
            _cinemachineTargetPitch += _input.look.y * deltaTimeMultiplier;
        }

        // clamp our rotations so our values are limited 360 degrees
        _cinemachineTargetYaw = ClampAngle(_cinemachineTargetYaw, float.MinValue, float.MaxValue);
        _cinemachineTargetPitch = ClampAngle(_cinemachineTargetPitch, BottomClamp, TopClamp);

        // Cinemachine will follow this target
        CinemachineCameraTarget.transform.rotation = Quaternion.Euler(_cinemachineTargetPitch + CameraAngleOverride,
            _cinemachineTargetYaw, 0.0f);
    }
}
