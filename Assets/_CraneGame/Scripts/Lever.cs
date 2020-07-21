using UnityEngine;
using UnityEngine.Events;

public class Lever : MonoBehaviour
{
    public HingeJoint hinge;
    public GameObject highlightVolume;
    public float deadzoneAngle;

    [System.Serializable]
    public class LeverEvent : UnityEvent{}
    
    public LeverEvent onValueChanged;
    
    private float value;
    //private LineRenderer lr;

    private void Start()
    {
        Highlight(false);
    }

    public void Update()
    {
        float lastValue = value;
        // assume damping target is 0
        float percent = hinge.angle < 0 ? -hinge.angle / hinge.limits.max : hinge.angle / hinge.limits.min;
        value = Mathf.Abs(hinge.angle) < deadzoneAngle ? 0 : percent;
        
        // Active Input Values
        if (lastValue != value)
            for(int i = 0; i < onValueChanged.GetPersistentEventCount(); i++)
                ((MonoBehaviour)onValueChanged.GetPersistentTarget(i)).SendMessage(onValueChanged.GetPersistentMethodName(i),value);

        // Debug.Log(ReadAxis());
    }

    // Returns a value from -1 to 1 denoting the state of this lever
    public float ReadAxis()
    {
        return value;
    }

    public void Highlight(bool active)
    {
        highlightVolume.SetActive(active);
    }
}
