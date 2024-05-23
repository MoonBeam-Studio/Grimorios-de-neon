using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResourceMangerScript : MonoBehaviour
{
    public RunTimeDataScriptableObject _runTimeData;
    public int ManaTime, EnergyTime, ManaRegenPerSecond, EnergyRegenPerSecond;
    [SerializeField] private int Vida, Mana, Energia;
    private float LastManaSpendTime, LastEnergySpendTime;
    private bool IsManaRegenActive, IsEnergyRegenActive, StopManaRegen, StopEnergyRegen;
    private Coroutine ManaRegenCoroutine, EnergyRegenCoroutine;

    private void OnEnable()
    {
        _runTimeData.CurrentHealth = _runTimeData.MaxHealth;
        _runTimeData.CurrentEnergy = _runTimeData.MaxEnergy;
        _runTimeData.CurrentMana = _runTimeData.MaxMana;

        _runTimeData.CurrentHealingCharges = _runTimeData.MaxHealingCharges;
        _runTimeData.CurrentUpgradeSlots = _runTimeData.MaxUpgradeSlots;
    }

    private void Update()
    {
        Vida = _runTimeData.CurrentHealth;
        Mana = _runTimeData.CurrentMana;
        Energia = _runTimeData.CurrentEnergy;
        if ((Time.time - LastManaSpendTime) >= ManaTime && _runTimeData.CurrentMana != _runTimeData.MaxMana && !IsManaRegenActive)
            ManaRegenCoroutine = StartCoroutine(ManaRegeneration());
        if ((Time.time - LastEnergySpendTime) >= EnergyTime && _runTimeData.CurrentEnergy != _runTimeData.MaxEnergy && !IsEnergyRegenActive) 
            EnergyRegenCoroutine = StartCoroutine(EnergyRegeneration());
    }

    IEnumerator ManaRegeneration()
    {
        IsManaRegenActive = true;
        while (_runTimeData.CurrentMana < _runTimeData.MaxMana)
        {
            yield return new WaitForSeconds(1);
            if (StopManaRegen) break;
            RegenMana(ManaRegenPerSecond);
        }
        StopManaRegen = false;
        IsManaRegenActive = false;
    }
    IEnumerator EnergyRegeneration()
    {
        IsEnergyRegenActive = true;
        while (_runTimeData.CurrentEnergy < _runTimeData.MaxEnergy)
        {
            yield return new WaitForSeconds(1);
            if (StopEnergyRegen) break;
            RegenEnergy(EnergyRegenPerSecond);
            Debug.Log("Energy Regen");
        }
        StopEnergyRegen = false;
        IsEnergyRegenActive = false;
    }

    public void GetDamaged(int DamageTaken)
    {
        _runTimeData.CurrentHealth -= DamageTaken;
    }

    public void GetHealed(int LifeHealed)
    {
        _runTimeData.CurrentHealth += LifeHealed;
        if(_runTimeData.CurrentHealth > _runTimeData.MaxHealth)
            _runTimeData.CurrentHealth = _runTimeData.MaxHealth;
    }

    public bool SpendMana(int ManaCost)
    {
        StopManaRegen = true;
        _runTimeData.CurrentMana -= ManaCost;
        LastManaSpendTime = Time.time;
        if(_runTimeData.CurrentMana <= 0)
        {
            _runTimeData.CurrentMana = 0;
            return false;
        } 
        else return true;
    }

    public void RegenMana(int ManaRegen)
    {
        _runTimeData.CurrentMana += ManaRegen;
        if (_runTimeData.CurrentMana > _runTimeData.MaxMana)
            _runTimeData.CurrentMana = _runTimeData.MaxMana;
    }

    public bool SpendEnergy(int EnergyCost)
    {
        StopEnergyRegen = true;
        _runTimeData.CurrentEnergy -= EnergyCost;
        LastEnergySpendTime = Time.time;
        Debug.Log(LastEnergySpendTime);
        if (_runTimeData.CurrentEnergy <= 0)
        {
            _runTimeData.CurrentEnergy = 0;
            return false;
        }
        else return true;
    }

    public void RegenEnergy(int EnergyRegen)
    {
        _runTimeData.CurrentEnergy += EnergyRegen;
        if (_runTimeData.CurrentEnergy > _runTimeData.MaxEnergy)
            _runTimeData.CurrentEnergy = _runTimeData.MaxEnergy;
    }

    public void Rest()
    {
        _runTimeData.CurrentHealth = _runTimeData.MaxHealth;
        _runTimeData.CurrentEnergy = _runTimeData.MaxEnergy;
        _runTimeData.CurrentMana = _runTimeData.MaxMana;

        _runTimeData.CurrentHealingCharges = _runTimeData.MaxHealingCharges;
        _runTimeData.CurrentUpgradeSlots = _runTimeData.MaxUpgradeSlots;
    }
}
