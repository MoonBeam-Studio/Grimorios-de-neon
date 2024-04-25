using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RipAndTear : MonoBehaviour
{
    
    [Header("Common Settings")]
    [SerializeField] private Transform CameraTransform;
    [SerializeField] private LayerMask HitteableLayer;
    [SerializeField] private int Damage;
    [SerializeField][Range(0,1)] private float MinDamagePercentage;

    [Header("Spear Settings")]
    [SerializeField][Range(0, 45)] private float MaxRotationX;
    [SerializeField][Range(0, 45)] private float MaxRotationY;
    [SerializeField][Range(90,135)] private float MaxRotationZ;
    [SerializeField] private GameObject SpearPrefab;

    [Header("Chain Settings")]
    [SerializeField] Material ChainMaterial;
    [SerializeField] Transform ChainHandPosition;
    private Transform BottomPosition;


    private void OnEnable()
    {
        EventManager.Instance.OnSpellCast += CastSpell;
        EventManager.Instance.OnSpellRelease += ReleaseSpell;
    }

    private void OnDisable()
    {
        EventManager.Instance.OnSpellCast -= CastSpell;
        EventManager.Instance.OnSpellRelease -= ReleaseSpell;
    }

    private void CastSpell()
    {
        Debug.Log("CastSpell - Spell");
        RaycastHit hit;
        Ray ray = new Ray(CameraTransform.position, CameraTransform.forward);
        Debug.DrawLine(CameraTransform.position, CameraTransform.forward*5, Color.red, 30f);
        if(Physics.Raycast(ray, out hit, 5f, HitteableLayer))
        {
            Debug.Log("CastSpell - SpellHit");
            Vector3 SpearSpawnPosition = hit.transform.Find("Center").position;
            Vector3 SpearSpawnRotation = new Vector3(
                x: Random.Range(-MaxRotationX, MaxRotationX),
                y: Random.Range(-MaxRotationY, MaxRotationY),
                z: Random.Range(-MaxRotationZ, MaxRotationZ)
                );
            GameObject SpawnedSpear = Instantiate(SpearPrefab, SpearSpawnPosition, Quaternion.Euler(SpearSpawnRotation), hit.transform);
        }
    }

    private void ReleaseSpell()
    {
        
    }
}
