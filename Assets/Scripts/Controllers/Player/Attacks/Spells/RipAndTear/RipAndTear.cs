using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class RipAndTear : MonoBehaviour
{
    
    [Header("Common Settings")]
    [SerializeField] private Transform RayOriginTransform;
    [SerializeField] private LayerMask HitteableLayer;
    [SerializeField] private int Damage, ManaCost = 2;
    [SerializeField][Range(0,1)] private float MinDamagePercentage;
    [SerializeField] private float MaxCastRadius = 5f, MaxReleaseRadius = 20f;


    [Header("Spear Settings")]
    [SerializeField][Range(0, 45)] private float MaxRotationX;
    [SerializeField][Range(0, 45)] private float MaxRotationY;
    [SerializeField][Range(90,135)] private float MaxRotationZ;
    [SerializeField] private GameObject SpearPrefab;

    [SerializeField]private int SpearNumber = 0;

    private Spear SpearController;
    private PlayerResourceMangerScript _resourceManager;

    private void Awake()
    {
        _resourceManager = GetComponent<PlayerResourceMangerScript>();
    }

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
        RaycastHit hit;
        Ray ray = new Ray(RayOriginTransform.position, RayOriginTransform.forward);
        Debug.Log("Spell trying to cast");
        Debug.DrawLine(RayOriginTransform.position, RayOriginTransform.forward * 5, Color.red, 3f);
        if (Physics.Raycast(ray, out hit, MaxCastRadius, HitteableLayer) && _resourceManager.SpendMana(ManaCost))
        //if(Physics.BoxCast(RayOriginTransform.position,new Vector3(transform.localScale.x, transform.localScale.y/2,MaxCastRadius), transform.forward, out hit, transform.rotation, MaxCastRadius, HitteableLayer) && _resourceManager.SpendMana(ManaCost))
        {
            Debug.Log("Spell Casted");
            GameObject SpawnParent = GameObject.Find($"/{hit.transform.name}/Center");
            Vector3 SpearSpawnRotation = new Vector3(
                x: 0,
                y: 0,
                z: 0
                );
            Vector3 SpearSpawnScale = new Vector3(0.01f, .1f, 0.01f);
            Vector3 SpearSpawnPosition = SpawnParent.transform.position;

            GameObject SpawnedSpear = Instantiate(SpearPrefab, SpawnParent.transform);
            SpawnedSpear.transform.name = $"Spear{SpearNumber}";
            SpearNumber++;
            SpawnedSpear.transform.localScale = SpearSpawnScale;
            SpawnedSpear.transform.position = SpearSpawnPosition;
            SpawnedSpear.transform.LookAt(transform.position);
            SpawnedSpear.transform.rotation = Quaternion.Euler(SpawnedSpear.transform.rotation.eulerAngles * -1) ;

            SpearController = SpawnedSpear.GetComponent<Spear>();
            SpearController.SpearDestination = SpearSpawnPosition;

            SpawnParent.GetComponentInParent<IEnemy>().TakeDamage(Damage * MinDamagePercentage, DamageType.RipAndTearCast);
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
                    EnemyInArea.GetComponent<IEnemy>().TakeDamage(Damage, DamageType.RipAndTearRelease);
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
