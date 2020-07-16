﻿using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Magnet : MonoBehaviour
{
    public Boolean buttonPress=false; //unsure how you plan to have this value change, feel free to add a simple function to
                                //change the value of this boolean when the button is pressed, or make this an external reference

    public void OnTriggerEnter(Collider other)
    {
        if (buttonPress == true)
        {
            Debug.Log("true");
            // attachedObject = other.gameObject;
            other.gameObject.GetComponent<Rigidbody>().useGravity = false;
            other.gameObject.transform.SetParent(this.transform);
            other.gameObject.transform.position = new Vector3(0f, 0f, 0f);
            Debug.Log("Parented");
            StartCoroutine(CheckFalse(other.gameObject));
        }
    }

    IEnumerator CheckFalse(GameObject attached)
    {
        if (buttonPress == true) 
        {
            yield return null;
            Debug.Log("Still True");        }
        if (buttonPress == false) 
        {
            attached.transform.SetParent(null);
            attached.gameObject.GetComponent<Rigidbody>().useGravity = true;
            Debug.Log("False, dropping item");
        }
    }

}
