using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(!other.gameObject.CompareTag("Customer")){return;}

        GetComponentInChildren<Light>().enabled = false;
    }    
    private void OnTriggerExit(Collider other)
    {
        if(!other.gameObject.CompareTag("Customer")){return;}

        GetComponentInChildren<Light>().enabled = true;
    }
}
