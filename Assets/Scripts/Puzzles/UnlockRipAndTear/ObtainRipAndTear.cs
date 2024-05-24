using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObtainRipAndTear : InteractuableObject
{
    ArchivementGiver ArchivementGiver;

    private void Awake() => ArchivementGiver = GetComponent<ArchivementGiver>();

    public override void Interact()
    {
        ArchivementGiver.GiveArchivement();
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<InteractHub>().enabled = false;
    }

}
