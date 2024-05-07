using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class PlayerGlich : MonoBehaviour
{
    public bool InCombat;
    public int EnergyPerSecond;

    public bool InGlichState;
    private CharacterController _characterController;
    private StarterAssetsInputs _inputs;
    private PlayerResourceMangerScript _resourceManager;
    private ThirdPersonController _thirdPersonController;

    [SerializeField] private LayerMask GlicheableLayers;
    [SerializeField] private LayerMask NoneLayer;
    [SerializeField] private float SpeedBoost;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _inputs = GetComponent<StarterAssetsInputs>();
        _resourceManager = GetComponent<PlayerResourceMangerScript>();
        _thirdPersonController = GetComponent<ThirdPersonController>();
    }

    private void Update()
    {
        if (InGlichState)
        {
            _characterController.excludeLayers = GlicheableLayers;
            _thirdPersonController.MoveSpeed = 2 * (1 + SpeedBoost);
            _thirdPersonController.SprintSpeed = 5.335f * (1 + SpeedBoost);
        }
        else
        {
            _characterController.excludeLayers = NoneLayer;
            _thirdPersonController.MoveSpeed = 2f;
            _thirdPersonController.SprintSpeed = 5.335f;
            StopAllCoroutines();
        }
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
        if (InGlichState || _resourceManager._runTimeData.CurrentMana <= 0)
        {            
            InGlichState = false;
        }
        else
        {
            StartCoroutine(ConsumeEnergy());
            InGlichState = true;
        }
    }

    private void GlichDodge()
    {
        _characterController.Move(new Vector3(_inputs.move.x, 0, _inputs.move.y)*.1f);
    }

    private IEnumerator ConsumeEnergy()
    {
        while (_resourceManager._runTimeData.CurrentEnergy > 0)
        {
            if (_resourceManager.SpendEnergy(EnergyPerSecond))
            {
                yield return new WaitForSeconds(1);
            }
            else InGlichState = false;
        }
    }
}
