using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance { get; private set; }
    private void Awake() {Instance = this;}

    // Delegates and Events \\

    //-| Player
    //--|Habilities
    public delegate void Glich();
    public event Glich OnGlich;

    //--| Misc
    public delegate void ShowAim();
    public event ShowAim OnShowAim;

    //--| Attack
    //---| Spells
    public delegate void SpellCast();
    public event SpellCast OnSpellCast;

    public delegate void SpellRelease();
    public event SpellRelease OnSpellRelease;


    // Events Invoking \\

    //-| Player
    //--|Habilities
    public void GlichEvent() => OnGlich?.Invoke();

    //--| Misc
    public void ShowAimEvent() => OnShowAim?.Invoke();

    //--| Attack
    //---| Spells
    public void SpellCastEvent() => OnSpellCast?.Invoke();
    public void SpellReleaseEvent() => OnSpellRelease?.Invoke();
}
