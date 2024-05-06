using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGlich : MonoBehaviour
{
    public bool InCombat;

    private bool InGlichState;
    private CharacterController _characterController;
    private StarterAssetsInputs _inputs;

    [SerializeField] private LayerMask GlicheableLayers;
    [SerializeField] private LayerMask NoneLayer;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _inputs = GetComponent<StarterAssetsInputs>();
    }

    private void Update()
    {
        Debug.Log(_inputs.move);
    }

    private void OnEnable()
    {
        EventManager.Instance.OnGlich += GlichActivate;
    }

    private void OnDisable()
    {
        EventManager.Instance.OnGlich -= GlichActivate;
    }

    private void GlichActivate()
    {
        if (InCombat) GlichDodge();
        else GlichState();
    }

    private void GlichState()
    {
        Debug.Log("Glich | State");
        if (InGlichState)
        {
            _characterController.excludeLayers = NoneLayer;
            InGlichState = false;
        }
        else
        {
            _characterController.excludeLayers = GlicheableLayers;
            InGlichState = true;
        }
    }

    private void GlichDodge()
    {
        Debug.Log("Glich | Dodge");
        //_characterController.SimpleMove(new Vector3(_inputs.move.x, 0, _inputs.move.y));
        _characterController.Move(new Vector3(_inputs.move.x, 0, _inputs.move.y)*.1f);
    }
}
