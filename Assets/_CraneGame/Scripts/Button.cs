using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    public bool toggle; // Is this button a toggle
    public GameObject highlightVolume;

    public Renderer model;
    public Material onMaterial;
    public Material offMaterial;
    
    public bool state; // ignored for non-toggle buttons
    public bool lastState;

    [System.Serializable]
    public class ButtonEvent : UnityEvent {}
    public ButtonEvent onActivate;
    public ButtonEvent onDeactivate;

    private void Start()
    {
        state = toggle && state;
        model.material = state ? onMaterial : offMaterial;
        onActivate.AddListener(updateMaterial);
        onDeactivate.AddListener(updateMaterial);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Press();
        if (Input.GetKeyUp(KeyCode.Space))
            UnPress();
    }

    private void LateUpdate()
    {
        lastState = state;
    }

    public void Highlight(bool active)
    {
        highlightVolume.SetActive(active);
    }

    public void Press()
    {
        lastState = state;
        state = !toggle || !state;
        if (lastState != state)
            if (state)
                onActivate.Invoke();
            else
                onDeactivate.Invoke();
    }

    public void UnPress()
    {
        lastState = state;
        state = toggle && state;
        if (lastState != state)
            onDeactivate.Invoke();
    }

    private void updateMaterial()
    {
        model.material = state ? onMaterial : offMaterial;
    }
}
