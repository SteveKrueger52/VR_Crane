using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class ControlDeck : MonoBehaviour
{
    public CraneMovement crane;
    
    // Lever Callbacks
    public void SlewChanged(float value)      { crane.OnInputChanged(0, value); }
    public void PitchChanged(float value)     { crane.OnInputChanged(2, value); }
    public void TelescopeChanged(float value) { crane.OnInputChanged(1, value); }
    public void ChainChanged(float value)     { crane.OnInputChanged(3, value); }

}
