// using System.Collections;
// using System.Collections.Generic;
// using TMPro;
// using UnityEngine;
// using UnityEngine.UI;

// public class interactable : MonoBehaviour
// {
//     [Header("Components")]
//     [SerializeField] private string tip;
//     [SerializeField] private TextMeshPro tipMesh;
//     [Header("Value")]
//     [SerializeField] private float timeToReset = 2f;
    
//     public void ValidInteraction()
//     {
//         tipMesh.text = tip;
//         Invoke("ResetTip", timeToReset);
//     }
    
//     public void InteractionTooFar()
//     {
//         tipMesh.text = "Get closer..";
//         Invoke("ResetTip", timeToReset);
//     }

//     private void ResetTip()
//     {
//         tipMesh.text = "";
//     }

//     public void ShowObjectTip()
//     {
//         tipMesh.text = "Washing machine";
//         Invoke("ResetTip", timeToReset);
//     }
// }
