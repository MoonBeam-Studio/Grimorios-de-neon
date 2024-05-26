using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    public void TakeDamage(float DamageValue, DamageType damageType);
    public void Die();
}
