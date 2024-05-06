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
    public delegate void CameraSwich();
    public event CameraSwich OnCameraSwich;

    //--| Attack
    //---| Spells
    public delegate void SpellCast();
    public event SpellCast OnSpellCast;

    public delegate void SpellRelease();
    public event SpellRelease OnSpellRelease;


    // Events Invoking \\

    //-| Player
    //--|Habilities
    public void GlichEvent() { OnGlich?.Invoke(); Debug.Log("Glich | Event"); }

    //--| Misc
    public void SwitchCameraEvent() => OnCameraSwich?.Invoke();

    //--| Attack
    //---| Spells
    public void SpellCastEvent() => OnSpellCast?.Invoke();
    public void SpellReleaseEvent() => OnSpellRelease?.Invoke();
}
