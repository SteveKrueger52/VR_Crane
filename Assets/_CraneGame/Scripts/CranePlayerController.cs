using UnityEngine;
using UnityEngine.InputSystem;

public class CranePlayerController : MonoBehaviour
{
    public CraneMovement crane;
    public Magnet magnet;
    public RaiseLowerRope raiselowerrope;

    public bool magnetToggle = false;

    // for Vertical axes, positive is always Up (away from the player)
    // For Horizontal axes, positive is always Right

    // TODO The implementation for the controls these represent should be done elsewhere.
    // TODO This is a temporary script to facilitate the testing of those features.

    // Left Stick X Axis or Lever 1: Positive turns crane right, Negative Left.
    public void OnRotateCrane(InputValue value)
    {
        //Debug.Log("Rotate Crane: " + value.Get<float>());
        crane.OnInputChanged(0, value.Get<float>());
    }

    // Left Stick Y Axis or Lever 2: Positive extends boom, negative retracts.
    public void OnExtendBoom(InputValue value)
    {
        //Debug.Log("Extend Boom: " + value.Get<float>());
        crane.OnInputChanged(1, value.Get<float>());
    }

    // Right Stick Y Axis or Lever 3: Positive rotates the boom down, Negative up.
    public void OnRotateBoom(InputValue value)
    {
        //Debug.Log("Rotate Boom: " + value.Get<float>());
        crane.OnInputChanged(2, value.Get<float>());
    }


    // Right Stick X Axis: Positive extends cable (down), Negative retracts (up)
    public void OnExtendChain(InputValue value)
    {
        //Debug.Log("Extend Chain: " + value.Get<float>());
        crane.OnInputChanged(3, value.Get<float>());
        //raiselowerrope.OnLeverMove(value.Get<float>());
    }

    public void OnMagnetToggle()
    {
        magnetToggle = !magnetToggle;
        if (magnetToggle)
            magnet.Pickup();
        else
            magnet.Drop();
    }
}