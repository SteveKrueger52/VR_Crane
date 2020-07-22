using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class ButtonInteractable : MonoBehaviour
{
    [System.Serializable]
    public class ButtonPressedEvent : UnityEvent { }
    [System.Serializable]
    public class ButtonReleasedEvent : UnityEvent { }

    public Vector3 Axis = new Vector3(0,-1,0 );
    public float MaxDistance;
    public float ReturnSpeed = 10.0f;
    
    public ButtonPressedEvent OnButtonPressed;
    public ButtonReleasedEvent OnButtonReleased;
    
    Vector3 m_StartPosition;
    Rigidbody m_Rigidbody;
    Collider m_Collider;

    bool m_Pressed;
    bool m_collidingWithInteractor;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Collider = GetComponentInChildren<Collider>();
        m_StartPosition = transform.localPosition;
    }

    void FixedUpdate()
    {
        Vector3 worldAxis = transform.TransformDirection(Axis);
        Vector3 end = transform.position + worldAxis * MaxDistance;
        
        float m_CurrentDistance = (transform.localPosition - m_StartPosition).magnitude;
        RaycastHit info;

        float move = 0.0f;
        float checkDistance = Mathf.Min(ReturnSpeed * Time.deltaTime, m_CurrentDistance);
        if (m_Rigidbody.SweepTest(-worldAxis, out info, checkDistance + 0.005f))
        {
            //hitting something, if the contact is < mean we are pressed, move downward
            move = (ReturnSpeed * Time.deltaTime) - info.distance;
        }
        else if (m_collidingWithInteractor)
        {
            //Player interactor attempting to press button from beneath
            move = (ReturnSpeed * Time.deltaTime);
        }
        else
        {
            move -= ReturnSpeed * Time.deltaTime;
        }

        float newDistance = Mathf.Clamp(m_CurrentDistance + move, 0, MaxDistance);

        m_Rigidbody.position = (Vector3)(transform.localToWorldMatrix * m_StartPosition) + worldAxis * newDistance;

        if (!m_Pressed && Mathf.Approximately(newDistance, MaxDistance))
        {//was just pressed
            m_Pressed = true;
            OnButtonPressed.Invoke();
        }
        else if (m_Pressed && !Mathf.Approximately(newDistance, MaxDistance))
        {//was just released
            m_Pressed = false;
            OnButtonReleased.Invoke();
        }
    }

#if UNITY_EDITOR
    void OnDrawGizmosSelected()
    {
        Handles.DrawLine(transform.position, transform.position + transform.TransformDirection(Axis).normalized * MaxDistance);
    }
#endif
}
