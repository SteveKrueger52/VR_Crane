using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public Rigidbody hook;
    public List<PickUpObject> selected;
    public PickUpObject attached;

    public SFXController sfxController;
    
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            selected.Add(other.gameObject.GetComponent<PickUpObject>());
            other.gameObject.GetComponent<PickUpObject>().Highlight(true);
        }
    }
    
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Item")
        {
            selected.Remove(other.gameObject.GetComponent<PickUpObject>());
            other.gameObject.GetComponent<PickUpObject>().Highlight(false);
        }
    }

    public void Pickup()
    {
        PickUpObject closest = null;
        foreach (PickUpObject obj in selected)
        {
            if (closest != null &&
                (closest.transform.position - hook.position).magnitude >
                (obj.transform.position - hook.position).magnitude)
                closest = obj;
            else
                closest = obj;
        }

        attached = closest;

        if (attached != null)
        {
            attached.Attach(hook);
            sfxController.OnPickedUp();
            sfxController.PositiveBeep();
        }
            
    }

    public void Drop()
    {
        if (attached != null)
        {
            attached.Attach(null);
            attached = null;
        }
    }
}
