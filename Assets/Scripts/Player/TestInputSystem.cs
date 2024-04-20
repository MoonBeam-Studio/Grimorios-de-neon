using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestInputSystem : MonoBehaviour
{

    private PlayerInput _PlayerInput;
    private InputAction Movement;

    private void Start()
    {
        _PlayerInput = GetComponent<PlayerInput>();

        Movement = _PlayerInput.actions.FindAction("Look");
    }

    private void Update()
    {
        Test();
    }

    private void Test()
    {
        Debug.Log(Movement.ReadValue<Vector2>());
    }
}
