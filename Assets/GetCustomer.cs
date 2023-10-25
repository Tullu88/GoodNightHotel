using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCustomer : MonoBehaviour
{
    private WandererAI ai;
    
    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Customer")){return;}

        ai = other.GetComponent<WandererAI>();
    }    
    private void OnTriggerExit(Collider other)
    {
        if(!other.CompareTag("Customer")){return;}
        ai = null;
    }

    public void TryToScare()
    {
        if(ai == null) {return;}

        ai.isScared = true;
    }
}
