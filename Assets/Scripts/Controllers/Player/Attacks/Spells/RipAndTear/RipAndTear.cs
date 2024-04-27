using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class RipAndTear : MonoBehaviour
{
    
    [Header("Common Settings")]
    [SerializeField] private Transform CameraTransform;
    [SerializeField] private LayerMask HitteableLayer;
    [SerializeField] private int Damage;
    [SerializeField][Range(0,1)] private float MinDamagePercentage;
    [SerializeField] private float MaxCastRadius = 5f, MaxReleaseRadius = 20f;


    [Header("Spear Settings")]
    [SerializeField][Range(0, 45)] private float MaxRotationX;
    [SerializeField][Range(0, 45)] private float MaxRotationY;
    [SerializeField][Range(90,135)] private float MaxRotationZ;
    [SerializeField] private GameObject SpearPrefab;

    private float _rotationVelocity;
    [SerializeField]private int SpearNumber = 0;

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

        if(Physics.Raycast(ray, out hit, MaxCastRadius, HitteableLayer))
        {
            GameObject SpawnParent = GameObject.Find($"/{hit.transform.name}/Center");
            Vector3 SpearSpawnRotation = new Vector3(
                x: 0,
                y: 0,
                z: 0
                );
            Vector3 SpearSpawnScale = new Vector3(0.05f, .5f, 0.05f);
            Vector3 SpearSpawnPosition = SpawnParent.transform.position;

            GameObject SpawnedSpear = Instantiate(SpearPrefab, SpawnParent.transform);
            SpawnedSpear.transform.name = $"Spear{SpearNumber}";
            SpearNumber++;
            SpawnedSpear.transform.localScale = SpearSpawnScale;
            SpawnedSpear.transform.position = SpearSpawnPosition;
            SpawnedSpear.transform.LookAt(transform.position);
            SpearPrefab.transform.rotation = Quaternion.Euler(SpearPrefab.transform.rotation.eulerAngles * -1) ;

            //float DesiredAngle = Vector3.Angle(transform.forward, hit.transform.position - transform.position);
            //StartCoroutine(LookAtTarget(DesiredAngle));
        }
    }

    private void ReleaseSpell()
    {
        Collider[] HittedEnemiesColliders = Physics.OverlapSphere(transform.position, MaxReleaseRadius, HitteableLayer);

        foreach (var EnemyInArea in HittedEnemiesColliders)
        {
            if (GameObject.Find($"/{EnemyInArea.gameObject.name}/Center") != null)
            {
                foreach (Transform Spear in GameObject.Find($"/{EnemyInArea.gameObject.name}/Center").transform)
                {
                    Destroy(Spear.gameObject);
                    SpearNumber = 0;
                }
            }
        }

    }

    IEnumerator LookAtTarget(float DesiredAngle)
    {
        while (transform.eulerAngles.y != DesiredAngle)
        {
            Quaternion DesiredRotation = Quaternion.Euler(transform.eulerAngles.x, DesiredAngle, transform.eulerAngles.z);
            transform.rotation = Quaternion.Lerp(transform.rotation, DesiredRotation, Time.deltaTime * 10f);
            yield return null;
        }
    }
}
