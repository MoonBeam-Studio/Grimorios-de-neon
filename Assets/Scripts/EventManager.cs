using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance { get; private set; }
    private void Awake() {Instance = this;}

    // Delegates and Events \\

    //-| Player


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
    //--| Misc
    public void SwitchCameraEvent() => OnCameraSwich?.Invoke();

    //--| Attack
    //---| Spells
    public void SpellCastEvent() => OnSpellCast?.Invoke();
    public void SpellReleaseEvent() => OnSpellRelease?.Invoke();
}
