using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PriceMe : MonoBehaviour
{
    [SerializeField] private bool price0;
    [SerializeField] private bool price1;
    [SerializeField] private bool price2;
    
    private void Start()
    {
        TextMeshProUGUI priceUI;

        priceUI = GetComponent<TextMeshProUGUI>();

        if (price0)
        {
            priceUI.text = GameManager.instance.perk0Cost.ToString();
        }        
        if (price1)
        {
            priceUI.text = GameManager.instance.perk1Cost.ToString();
        }        
        if (price2)
        {
            priceUI.text = GameManager.instance.perk2Cost.ToString();
        }
    }
}
