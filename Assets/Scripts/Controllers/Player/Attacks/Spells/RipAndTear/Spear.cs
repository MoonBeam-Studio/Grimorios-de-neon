using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour
{
    private Transform SpearBottom;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Transform Hand;


    private void Start()
    {
        lineRenderer = GetComponentInChildren<LineRenderer>();
        SpearBottom = GameObject.Find($"{gameObject.name}/SpearBottom").transform;
        Hand = GameObject.Find("Player/Skeleton/Hips/Spine/Chest/UpperChest/Left_Shoulder/Left_UpperArm/Left_LowerArm/Left_Hand/SpellOutPosition").transform;

        ChainPositions();
    }

    private void Update()
    {
        ChainPositions();
    }

    private void ChainPositions()
    {
        lineRenderer.SetPosition(0, SpearBottom.position);
        lineRenderer.SetPosition(1, Hand.position);
    }


}
