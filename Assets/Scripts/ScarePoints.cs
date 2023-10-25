using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScarePoints : MonoBehaviour
{   
    TextMeshProUGUI scarePoints;
    //TextMeshProUGUI health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scarePoints = GetComponentInChildren<TextMeshProUGUI>();
        scarePoints.text = "Health points: " + GameManager.instance.currentScarePoints;

        // health = GetComponentInChildren<TextMeshProUGUI>();
        // health.text = "2";
    }
}
