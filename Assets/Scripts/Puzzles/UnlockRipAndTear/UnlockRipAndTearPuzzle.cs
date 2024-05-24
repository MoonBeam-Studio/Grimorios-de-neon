using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockRipAndTearPuzzle : InteractuableObject
{
    [SerializeField] GameObject Cover;

    public override void Interact()
    {
        Cover.SetActive(false);
        transform.position = new Vector3(transform.position.x, transform.position.y - .25f, transform.position.z);
        gameObject.GetComponent<InteractHub>().enabled = false;
    }
}
