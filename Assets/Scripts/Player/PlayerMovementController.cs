using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    private CharacterController controller;
    private Animator anim;
    private Transform cam;
    
    private float speedSmoothVelocity;
    private float speedSmoothTime;
    private float currentSpeed;
    private float velocityY;
    private Vector3 moveInput;
    private Vector3 dir;

    [Header("Settings")]
    [SerializeField] private float gravity = 25f;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float rotateSpeed = 3f;

    public bool lockMovement;
    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        cam = Camera.main.transform;
    }

    void Update()
    {
        
    }
}
