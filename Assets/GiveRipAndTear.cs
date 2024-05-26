using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveRipAndTear : MonoBehaviour
{
    [SerializeField] GameObject Player;


    void Start()
    {
        Player.GetComponent<RipAndTear>().enabled = true;
        Player.GetComponent<ShowAim>().enabled = true;
    }

}
