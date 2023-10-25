using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAction : MonoBehaviour
{
    
    Rigidbody childRigidbody;
    //private Rigidbody parentRigidbody;
    SwordSound swordSound;

    public bool isActive = false;

    void Start()
    {
        

        childRigidbody = GetComponentInChildren<Rigidbody>();
        swordSound = GetComponentInChildren<SwordSound>();
        //parentRigidbody = transform.parent.GetComponent<Rigidbody>();
        
    }

    public void Actions()
    {
            if (isActive == false)
            {   
                swordSound.activateForce();
                //parentRigidbody.AddForce(Vector3.down * 9.8f * 10f, ForceMode.Acceleration); 
                childRigidbody.useGravity = true;
                isActive = true;
            } 
            else {
                isActive = false;
            }
    }

    
}
