using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveGlich : MonoBehaviour
{
    [SerializeField] GameObject Player;


    void Start()
    {
        Player.GetComponent<PlayerGlich>().enabled = true;
    }

}

