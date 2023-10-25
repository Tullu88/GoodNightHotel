using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiStats : MonoBehaviour
{   
    TextMeshProUGUI timeOfDay;
    //TextMeshProUGUI health;
    // Start is called before the first frame update
    void Start()
    {
        timeOfDay = GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isDay == true){
            timeOfDay.text = "Daytime";
        } else if (GameManager.instance.isDay == false)
        {
            timeOfDay.text = "Night-time";
        }
        
        //health.text = "Scare points: " + GameManager.instance.;

        // health = GetComponentInChildren<TextMeshProUGUI>();
        // health.text = "2";
    }
}
