using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMagicCircle : MonoBehaviour
{
    [SerializeField] ParticleSystem darkSparks, sparks, sides, _light;


    private void OnTriggerExit(Collider other) { if (other.CompareTag("Player")) Dim(); }

    private void Start() => StartCoroutine(DimCoroutine());

    private IEnumerator DimCoroutine()
    {
        yield return new WaitForSeconds(3);
        Dim();
    }

    private void Dim()
    {
        sides.startColor = Color.clear;
        darkSparks.startColor = Color.clear;
        sparks.startColor = Color.clear;
        _light.startColor = Color.clear;
    }
}
