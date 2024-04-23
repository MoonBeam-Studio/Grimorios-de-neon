using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusCamera : MonoBehaviour
{
    [SerializeField] GameObject Pointer;
    [SerializeField] LayerMask PlayerLayer;
    private bool IsCameraActive;

    // Update is called once per frame
    void Update()
    {
        if (IsCameraActive) PlayerChecker();
    }

    private void OnEnable() => IsCameraActive = true;
    private void OnDisable() => IsCameraActive = false;

    private void PlayerChecker()
    {
        if (Physics.Raycast(transform.position, transform.forward, float.MaxValue, PlayerLayer))
            Pointer.gameObject.SetActive(false);

        else  Pointer.gameObject.SetActive(true);
    }
    
}
