using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour, IEnemy
{

    [SerializeField] private float MaxHealth, CurrentHealth;
    [SerializeField] private Collider _collider;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private GameObject[] ToDisableOnDead;
    // Start is called before the first frame update
    void Start()
    {
        _collider = GetComponent<Collider>();
        _collider.enabled = false;
        _agent = GetComponent<NavMeshAgent>();
        _agent.enabled = false;
        CurrentHealth = MaxHealth;
    }

    public void Activate()
    {
        _collider.enabled = true;
        _agent.enabled = true;
        Debug.Log("Activated");
    }
    public void TakeDamage(float Damage)
    {
        CurrentHealth -= Damage;

        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            Die();
        }
    }

    public void Die()
    {
        _collider.enabled = false;
        _agent.enabled = false;
        foreach (GameObject Disable in ToDisableOnDead)
        {
            if(Disable.name == "Center")
            {
                foreach(Transform Spear in Disable.transform)
                {
                    Destroy(Spear.gameObject);
                }
            }
            Disable.SetActive(false);
        }
    }
}
