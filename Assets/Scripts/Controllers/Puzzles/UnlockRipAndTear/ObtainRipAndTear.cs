using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObtainRipAndTear : InteractuableObject
{
    [SerializeField] Collider collider;
    ArchivementGiver ArchivementGiver;

    private void Awake() => ArchivementGiver = GetComponent<ArchivementGiver>();

    public override void Interact()
    {
        collider.enabled = false;
        //ArchivementGiver.GiveArchivement();
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<InteractHub>().DisplayMessage();
        //Activar Dialogo
        GetComponent<SceneChanger>().ChangeScene();
    }

}
