using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(LineRenderer))]
public class Lever : MonoBehaviour
{
    public HingeJoint hinge;
    public Rigidbody grabTarget;
    public GameObject highlightVolume;
    public float deadzoneAngle;

    private bool centered = true;

    [System.Serializable]
    public class LeverEvent : UnityEvent{}
    
    public LeverEvent onValueChanged;
    
    private float value;
    private LineRenderer lr;

    private void Start()
    {
        Highlight(false);
        lr = GetComponent<LineRenderer>();
        lr.useWorldSpace = true;
        lr.SetPosition(0,hinge.transform.position);
        lr.SetPosition(1,grabTarget.transform.position);
    }

    public void Update()
    {
        float lastValue = value;
        // assume damping target is 0
        float percent = hinge.angle < 0 ? -hinge.angle / hinge.limits.max : hinge.angle / hinge.limits.min;
        value = Mathf.Abs(hinge.angle) < deadzoneAngle ? 0 : percent;
        lr.SetPosition(0,hinge.transform.position);
        lr.SetPosition(1,grabTarget.transform.position);
        
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

    public void PullingLever(bool active)
    {
        centered = !active;
    }
    
    public void Recenter()
    {
        grabTarget.transform.parent = hinge.transform;
        grabTarget.transform.localPosition = Vector3.zero;
    }
}
