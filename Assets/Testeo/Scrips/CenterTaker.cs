using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterTaker : MonoBehaviour
{
    [SerializeField] private GameObject taker;

    private void Start() => taker = transform.Find("Center").gameObject;
    
}
