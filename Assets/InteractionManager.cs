// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class InteractionManager : MonoBehaviour
// { 
//     void Update()
//     {
//         DetectInteractable();
//     }

//     private void DetectInteractable()
//     {
//         if (Input.GetMouseButtonDown(0))
//         {
//             FindInteractable();
//         } 
//         // else {
//         //     ShowTip();
//         // }
//     }

//     // void ShowTip()
//     // {
//     //     var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//     //     RaycastHit hit;
//     //     var oldObject;
       
//     //     if (Physics.Raycast(ray, out hit))
//     //     {
//     //         if (hit.transform == null)
//     //         {
//     //             return;
//     //         }
            
//     //         var objInteract = hit.transform.GetComponent<interactable>();
//     //         oldObject = objInteract;
//     //         oldObject.ShowObjectTip();
//     //     }
//     // }

//     private void FindInteractable()
//     {
//         var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//         RaycastHit hit;

//         if (Physics.Raycast(ray, out hit))
//         {
//             if (hit.transform == null)
//             {
//                 return;
//             }

//             var dist = Vector3.Distance(hit.transform.position, transform.position);
//             var objInteract = hit.transform.GetComponent<interactable>();

//             if (objInteract == null)
//             {
//                 print("Can't find valid interactable");
//                 return;
//             }

//             if (dist > 6)
//             {
//                 objInteract.InteractionTooFar();
//                 return;
//             }

//             hit.transform.GetComponent<interactable>().ValidInteraction();
//         }
//     }
    
//     void OnMouseOver()
//     {
//         FindInteractable();
//     }
// }
