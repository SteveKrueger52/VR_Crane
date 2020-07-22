using UnityEngine;
using UnityEngine.Events;

public class VRButton : MonoBehaviour
{
    public bool toggle; // Is this button a toggle
    public GameObject highlightVolume;

    public Renderer model;
    public Material onMaterial;
    public Material offMaterial;


    
    public bool state; // ignored for non-toggle buttons
    
    private bool lastState;

    [System.Serializable]
    public class ButtonEvent : UnityEvent {}
    public ButtonEvent onActivate;
    public ButtonEvent onDeactivate;

    private void Start()
    {
        state = toggle && state;
        model.material = state ? onMaterial : offMaterial;
    }

    private void LateUpdate()
    {
        if (state != lastState)
        {
            if (state)
                onActivate.Invoke();
            else
                onDeactivate.Invoke();
        }
        lastState = state;
    }

    public void UpdateState(bool selecting)
    {
        if (toggle)
            state = selecting ? !state : state;
        else
            state = selecting;
        if (selecting)
            SFXController.Instance.OnButtonPress();
            
        Debug.Log("CODE RAN! VALUE: " + toggle + " : " + selecting + " : " + lastState + "-> " + state);
        updateMaterial();
    }
    
    public void Highlight(bool active)
    {
        highlightVolume.SetActive(active);
    }

    private void updateMaterial()
    {
        model.material = state ? onMaterial : offMaterial;
    }
}
