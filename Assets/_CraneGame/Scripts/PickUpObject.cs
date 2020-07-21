using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public SFXController sfxController;
    public Rigidbody anchor;
    public GameObject highlight;

    private SpringJoint spring;
    private bool attached;

    private void Start()
    {
        spring = GetComponent<SpringJoint>();
    }

    public void Attach(Rigidbody other)
    {
        attached = other != null;
        spring.connectedBody = attached ? other : anchor;
        Highlight(false);
    }

    public void Highlight(bool active)
    {
        highlight.SetActive(active && !attached);
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "GroundTag")
        {
            sfxController.OnPutDown();
            sfxController.NegativeBeep();
        }
        else if (collision.gameObject.tag == "GoalZone")
        {
            sfxController.OnPutDown();
            sfxController.PositiveBeep();
        }
    }
}
