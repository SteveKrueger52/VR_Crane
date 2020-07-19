using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXController : MonoBehaviour
{
    public AudioSource ObjectPickUp;
    public AudioSource PositiveBeepSound;
    public AudioSource NegativeBeepSound;
    public AudioSource ObjectDropped;
    public AudioSource EngineOn;
    public AudioSource EngineOff;

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
        ObjectDropped.Play();
    }

    public void PositiveBeep()
    {
        PositiveBeepSound.Play();
    }

    public void NegativeBeep()
    {
        NegativeBeepSound.Play();
    }

    public void OnEngineStart()
    {
        EngineOn.Play();
    }

    public void OnEngineStop()
    {
        EngineOff.Play();
    }
}
