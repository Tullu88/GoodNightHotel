using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractInput : MonoBehaviour
{
    Ray ray;
    InteractableObject lastObject;
    bool isClicked = true;
    [SerializeField] GameObject uiWarning;
    float distance;
    UiWarning warningAction;

    [SerializeField] private float interactDist = 2.7f;

    // Need to make raycast ignore player
    public LayerMask layerMask;
    public Texture2D defaultCursorTexture;
    public Texture2D interactCursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    void Awake()
    {
        warningAction = uiWarning.GetComponentInChildren<UiWarning>();

        // Set default cursor
        Cursor.SetCursor(defaultCursorTexture, hotSpot + new Vector2(55, 40), cursorMode);
    }

    void Update()
    {
        CheckInteractObject();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, interactDist);
        Gizmos.color = Color.cyan;
    }

    void Dist(Transform objectPosition) 
    {
        distance = Vector3.Distance(gameObject.transform.position, objectPosition.position);
    }

    void CheckInteractObject()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        

        if (Physics.Raycast(ray, out hit))
            {
                Dist(hit.transform);
                InteractableObject interactableObject = hit.transform.GetComponent<InteractableObject>();
                
                // These lines are for testing
                GameObject currentObject = hit.transform.gameObject;
                string objectName = currentObject.name;
                // --
                // GameObject instance = hit.transform.gameObject;
                // int instanceID = hit.transform.gameObject.GetInstanceID();

                if (interactableObject != null)
                {
                    // print("II Script: This is the object being interacted with: " + objectName);
                    // print("This is gameobject instance id: " + instanceID);
                    //print("Interactable object: " + interactableObject);

                    // This changes the cursor texture
                    Cursor.SetCursor(interactCursorTexture, hotSpot + hotSpot + new Vector2(130, 380), cursorMode);
                    // interactableObject.ActivationAction();
                    lastObject = interactableObject;
                    
                } else if (lastObject != null) {

                    // Resets the cursor
                    Cursor.SetCursor(defaultCursorTexture, hotSpot + new Vector2(55, 40), cursorMode);
                    
                    lastObject = null;
                    
                }

                // When attempting to interact with an object, this code will check
                //if the player is at the correct distance away from it, 
                //If so, he can interact with it.
                if (Input.GetMouseButtonDown(0) && distance > interactDist)
                {
                    if(interactableObject == null){ return; }
                    
                    print("Mouse button detected");
                    
                    warningAction.DisplayWarning();
                    
                } else if (Input.GetMouseButtonDown(0) && distance < interactDist) {

                    if (interactableObject != null)
                    {  
                        print("Interaction should fire here");
                         interactableObject.Interact();
                        warningAction.ResetWarning();
                        
                        return;
                    }
                }
            } 
                
        }
}
