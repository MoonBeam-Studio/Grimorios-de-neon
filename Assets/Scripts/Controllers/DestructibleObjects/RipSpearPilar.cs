using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class RipSpearPilar : MonoBehaviour, IEnemy
{
    [SerializeField] private RipSpearUnlockBridge puzzle;


    public void TakeDamage(float Damage, DamageType Type)
    {
        if(Type != DamageType.RipAndTearRelease) return;

        puzzle.Count(gameObject);
    }

    public void Die() { return; }
}
