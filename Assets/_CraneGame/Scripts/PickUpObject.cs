using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PickUpObject : MonoBehaviour
{
    public Rigidbody anchor;
    public GameObject highlight;

    public GameObject particlesys;


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
            SFXController.Instance.OnPutDown();
            SFXController.Instance.NegativeBeep();
        }
        else if (collision.gameObject.tag == "GoalZone")
        {

            SFXController.Instance.OnPutDown();
            SFXController.Instance.PositiveBeep();
            ParticleSystem ps = particlesys.GetComponent<ParticleSystem>();
            var main = ps.main;
            main.startColor = new Color(0,255,0,1);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "GoalZone")
        {
            ParticleSystem ps = particlesys.GetComponent<ParticleSystem>();
            var main = ps.main;
            main.startColor = new Color(255, 255, 255, 1);
        }
    }
}
