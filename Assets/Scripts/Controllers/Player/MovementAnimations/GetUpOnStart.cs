using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class GetUp : MonoBehaviour
{
    [SerializeField]private Animator _animator;

    private void Start()
    {
        _animator.SetTrigger("GetUp");
        gameObject.GetComponent<PlayerInput>().enabled = false;
    }

    public void AnimationEnd()
    {
        gameObject.GetComponent<PlayerInput>().enabled = true;
    }
}
