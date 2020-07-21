using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class HandAnimator : MonoBehaviour
{
    public float speed = 5.0f;

    public XRController controller;
    private Animator animator;
    private readonly List<Finger> gripFingers = new List<Finger>() {
        new Finger(FingerType.Index),
        new Finger(FingerType.Middle),
        new Finger(FingerType.Ring),
        new Finger(FingerType.Pinky),

    };

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    private void SetFingerTargets(List<Finger> fingers, float value)
    {
        foreach (Finger finger in fingers) {
            finger.target = value;
        }
    }

    private void Update() {
        CheckGrip();
        SmoothFinger(gripFingers);
        AnimateFinger(gripFingers);
    }

    private void CheckGrip() {
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.trigger, out float gripValue)) {
            SetFingerTargets(gripFingers, gripValue);
        };
    }
    // public void Grab(float input) {
    //     // Debug.Log("In grab");
    //     SetFingerTargets(gripFingers, 1);
    //     SmoothFinger(gripFingers);
    //     AnimateFinger(gripFingers);
    // }
    // public void Release() {
    //     // Debug.Log("In release");
    //     SetFingerTargets(gripFingers, 0);
    //     SmoothFinger(gripFingers);
    //     AnimateFinger(gripFingers);
    // }

    private void SmoothFinger(List<Finger> fingers)
    {
        foreach (Finger finger in fingers) {
            float time = speed * Time.unscaledDeltaTime;
            finger.current = Mathf.MoveTowards(finger.current, finger.target, time);
        }
    }

    private void AnimateFinger(List<Finger> fingers)
    {
        foreach (Finger finger in fingers) {
            AnimateFinger(finger.type.ToString(), finger.current);
        }
    }

    private void AnimateFinger(string finger, float blend)
    {
        animator.SetFloat(finger, blend);
    }

}