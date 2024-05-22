using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DitherMaterial : MonoBehaviour
{
    [SerializeField] Transform Player;
    [SerializeField] LayerMask EnviormentLayer;

    private void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, Player.position);

        if (Physics.Raycast(ray, out hit, float.MaxValue, EnviormentLayer))
        {
            Material HittedMaterial = hit.transform.GetComponent<Material>();
            if (HittedMaterial == null) return;
            HittedMaterial.color = new Color(0, 0, 0, 0);

        }
    }
}
