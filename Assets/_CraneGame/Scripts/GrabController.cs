using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabController: MonoBehaviour
{
    public GameObject handObject = null;
    private XRDirectInteractor interactor = null;
    private HandAnimator handAnimator;
    private void Awake()
    {
        interactor = GetComponent<XRDirectInteractor>();
        handAnimator = handObject.GetComponent<HandAnimator>();
    }

    private void OnEnable()
    {
        interactor.onSelectEnter.AddListener(Grab);
        interactor.onSelectExit.AddListener(Release);
    }

    private void OnDisable()
    {
        interactor.onSelectEnter.RemoveListener(Grab);
        interactor.onSelectExit.RemoveListener(Release);
    }

    private void Grab(XRBaseInteractable interactable)
    {
        Debug.Log("Grabbing");
        // handAnimator.Grab();
    }

    private void Release(XRBaseInteractable interactable)
    {
        Debug.Log("Releasing");
        // handAnimator.Release();
    }

    
}
