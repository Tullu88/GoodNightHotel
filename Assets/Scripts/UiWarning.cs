using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiWarning : MonoBehaviour
{
    TextMeshProUGUI textToChange;
    bool flag;

    void Start()
    {
        textToChange = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayWarning()
    {
        
        textToChange.text = "You must get closer";
        Invoke("ResetWarning", 3);
        
    }

    public void ResetWarning()
    {
        textToChange.text = " ";
    }
}
