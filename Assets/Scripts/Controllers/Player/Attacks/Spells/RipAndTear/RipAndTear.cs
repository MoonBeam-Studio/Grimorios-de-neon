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
    [SerializeField] private float MaxCastRadius = 5f, MaxReleaseRadius;


    [Header("Spear Settings")]
    [SerializeField][Range(0, 45)] private float MaxRotationX;
    [SerializeField][Range(0, 45)] private float MaxRotationY;
    [SerializeField][Range(90,135)] private float MaxRotationZ;
    [SerializeField] private GameObject SpearPrefab;

    [Header("Other Settings")]
    [SerializeField] private SphereCollider ReleaseCollider;
    

    private void OnEnable()
    {
        EventManager.Instance.OnSpellCast += CastSpell;
        EventManager.Instance.OnSpellRelease += ReleaseSpell;
        ReleaseCollider.enabled = false;
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

        if(Physics.Raycast(ray, out hit, MaxCastRadius, HitteableLayer))
        {
            

            GameObject SpawnParent = GameObject.Find($"/{hit.transform.name}/Center");
            Vector3 SpearSpawnRotation = new Vector3(
                x: Random.Range(0, MaxRotationX),
                y: Random.Range(0, MaxRotationY),
                z: Random.Range(90, MaxRotationZ)
                );
            Vector3 SpearSpawnScale = new Vector3(0.05f, .5f, 0.05f);
            Vector3 SpearSpawnPosition = SpawnParent.transform.position;


            GameObject SpawnedSpear = Instantiate(SpearPrefab, SpawnParent.transform);
            SpawnedSpear.transform.rotation = Quaternion.Euler(SpearSpawnRotation);
            SpawnedSpear.transform.localScale = SpearSpawnScale;
            SpawnedSpear.transform.position = SpearSpawnPosition;

        }
    }

    private void ReleaseSpell()
    {
        Debug.Log("ReleaseSpell - Spell");

        //ReleaseCollider.radius = MaxReleaseRadius;
        StartCoroutine(ColliderRadiusIncrementer());
        ReleaseCollider.enabled = true;

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Collider Casted {other.transform.name}");

        //ReleaseCollider.enabled = false;
    }

    IEnumerator ColliderRadiusIncrementer()
    {
        for (int i = 0; i <= MaxReleaseRadius; i++)
        {
            ReleaseCollider.radius = i;
            yield return new WaitForSeconds(.1f);
        }
    }
}
