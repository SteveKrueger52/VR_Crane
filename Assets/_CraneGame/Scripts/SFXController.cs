using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXController : MonoBehaviour
{
    public AudioSource ObjectPickUp;
    public AudioSource PositiveBeepSound;
    public AudioSource NegativeBeepSound;
    public AudioSource ObjectDropped;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPickedUp()
    {
        ObjectPickUp.Play();
    }

    public void OnPutDown()
    {
        ObjectPickUp.Play();
    }

    public void PositiveBeep()
    {
        ObjectPickUp.Play();
    }

    public void NegativeBeep()
    {
        ObjectPickUp.Play();
    }
}
