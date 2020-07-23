using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class VRButton : MonoBehaviour
{
    public bool toggle; // Is this button a toggle
    public GameObject highlightVolume;

    public Renderer model;
    public Material onMaterial;
    public Material offMaterial;

    public SFXController sfxController;
    
    public bool state; // ignored for non-toggle buttons
    private bool lastState;

    // public InputAction debugPress;

    [System.Serializable]
    public class ButtonEvent : UnityEvent {}
    public ButtonEvent onActivate;
    public ButtonEvent onDeactivate;

    private void Start()
    {
        state = toggle && state;
        model.material = state ? onMaterial : offMaterial;
//        debugPress.Enable();
//        debugPress.started += ctx => Press(ctx);
//        debugPress.canceled += ctx => Unpress(ctx);
//        debugPress.performed += ctx => Unpress(ctx);

    }

    private void Press(InputAction.CallbackContext ctx)
    {
        UpdateState(true);
        Debug.Log("Pressed");
    }
    
    private void Unpress(InputAction.CallbackContext ctx)
    {
        UpdateState(false);
        Debug.Log("Released: " + (ctx.performed ? "Performed" : "Canceled"));
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
            sfxController.OnButtonPress();
            
        // Debug.Log("CODE RAN! VALUE: " + toggle + " : " + selecting + " : " + lastState + "-> " + state);
        updateMaterial();
        
        // Value Actually Changed
    }

    private void updateMaterial()
    {
        model.material = state ? onMaterial : offMaterial;
    }

    public void Highlight(bool active)
    {
        highlightVolume.SetActive(active);
    }
    
}
