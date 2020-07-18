using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public SFXController sfxController;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
