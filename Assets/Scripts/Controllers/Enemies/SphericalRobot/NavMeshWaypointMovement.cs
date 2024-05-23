using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshWaypointMovement : MonoBehaviour
{
    [SerializeField] Transform[] Waypoints;
    [SerializeField] float WaitTime;

    private float WaitCounter;
    private Transform ObjetiveWaypoint;
    [SerializeField]private int CurrentWaypoint;
    private bool IsWaiting;
    private NavMeshAgent navMeshAgent;
    private Animator animator;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (IsWaiting)
        {
            animator.SetBool("Walk_Anim", false);
            WaitCounter += Time.deltaTime;
            if (WaitCounter >= WaitTime) IsWaiting = false;
        }
        else
        {
            Transform WaypointTransform = Waypoints[CurrentWaypoint];
            if (Vector3.Distance(transform.position, WaypointTransform.position) <= 0.85f)
            {
                WaitCounter = 0;
                IsWaiting = true;
                CurrentWaypoint = (CurrentWaypoint + 1) % Waypoints.Length;
            }
            else
            {
                animator.SetBool("Walk_Anim", true);
                navMeshAgent.SetDestination(WaypointTransform.position);
            }
        }
    }
}
