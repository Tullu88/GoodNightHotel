using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDoor : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Customer")){return;}
        
        _animator.SetBool("swing", true);


    }    
    private void OnTriggerExit(Collider other)
    {
        if(!other.CompareTag("Customer")){return;}
        
        _animator.SetBool("swing", false);
    }
}
