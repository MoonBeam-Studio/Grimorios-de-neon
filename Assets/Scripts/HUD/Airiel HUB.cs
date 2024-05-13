using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirielHUB : MonoBehaviour
{
    [SerializeField] ParticleSystem[] AirielParticleSystem;

    private void OnDisable()
    {
        DimAiriel();
    }

    public void DimAiriel()
    {
        foreach (ParticleSystem particle in AirielParticleSystem)
        {
            particle.startColor = Color.clear;
        }
    }
}
