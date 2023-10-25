using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class CharacterMovementInput : MonoBehaviour
{
    CharacterMovement characterMovement;
    [SerializeField] MouseInput mouseInput;

    private void Awake()
    {
        characterMovement = GetComponent<CharacterMovement>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(GameManager.instance.shopActive) {return;}
            
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if(hit.transform.GetComponent<InteractableObject>() != null){return;}
                
                characterMovement.SetDestination(mouseInput.mouseInputPosition);
            }  
        }
    }
}
