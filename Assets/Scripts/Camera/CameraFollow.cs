using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;
    [SerializeField] Vector2 clampAxis = new Vector2(60, 60);

    [SerializeField] float follow_smoothing = 5;
    [SerializeField] float rotate_Smoothing = 5;
    [SerializeField] float senstivity = 60;

    float rotX, rotY;
    bool cursorLocked = false;
    Transform cam;

    public bool lockedTarget;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
