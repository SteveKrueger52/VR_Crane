using UnityEngine;
using UnityEngine.InputSystem;

public class CranePlayerController : MonoBehaviour
{
   // for Vertical axes, positive is always Up (away from the player)
   // For Horizontal axes, positive is always Right
   
   // TODO The implementation for the controls these represent should be done elsewhere.
   // TODO This is a temporary script to facilitate the testing of those features.
   
   // Left Stick X Axis or Lever 1: Positive turns crane right, Negative Left.
   public void OnRotateCrane(InputValue value)
   {
      Debug.Log("Rotate Crane: " + value.Get<float>());
   }
   
   // Left Stick Y Axis or Lever 2: Positive extends boom, negative retracts.
   public void OnExtendBoom(InputValue value)
   {
      Debug.Log("Extend Boom: " + value.Get<float>());
   }
   
   // Right Stick Y Axis or Lever 3: Positive rotates the boom down, Negative up.
   public void OnRotateBoom(InputValue value)
   {
      Debug.Log("Rotate Boom: " + value.Get<float>());
   }
   
   
   // Right Stick X Axis: Positive extends cable (down), Negative retracts (up)
   public void OnExtendChain(InputValue value)
   {
      Debug.Log("Extend Chain: " + value.Get<float>());
   }
}
