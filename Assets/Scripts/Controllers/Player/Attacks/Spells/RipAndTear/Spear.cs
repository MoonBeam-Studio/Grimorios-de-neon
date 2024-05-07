using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour
{
    private Transform SpearBottom;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Transform Hand;
    [SerializeField] private Transform Player;
    [SerializeField] private Transform Head;

    public Vector3 SpearDestination;


    private void Start()
    {
        lineRenderer = GetComponentInChildren<LineRenderer>();
        SpearBottom = GameObject.Find($"{gameObject.name}/SpearBottom").transform;
        Hand = GameObject.Find("/Player/Skeleton/Hips/Spine/Chest/UpperChest/Left_Shoulder/Left_UpperArm/Left_LowerArm/Left_Hand/SpellOutPosition").transform;
        Head = GameObject.Find("/Player/Skeleton/Hips/Spine/Chest/UpperChest/Neck/Head").transform;
        Player = GameObject.Find("/Player").transform;


        transform.position = new Vector3(Player.position.x, (Head.position.y + 1), Player.position.z);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles * -1);

        StartCoroutine(GetToPosition());
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

    private IEnumerator GetToPosition()
    {
        Vector3 SpearOrigin = transform.position;
        float Distance = Vector3.Distance(SpearOrigin, SpearDestination);
        float RemainingDistance = Distance;

        while (transform.position != SpearDestination) 
        {

            transform.position = Vector3.Lerp(
                a: SpearOrigin,
                b: SpearDestination,
                t: Mathf.Clamp(
                    1 - (RemainingDistance / Distance),
                    0,
                    1)
                );
            RemainingDistance -= 20f * Time.deltaTime;
            yield return null;
        }
    }

}
