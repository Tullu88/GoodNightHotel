using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconMovement : MonoBehaviour
{
    float amplitude = 15f;
    float speed = 6f;

    float startingYPosition;

    float startingZRotation;
    float startingXRotation;
    float startingYRotation;

    void Start() 
    {
        startingYPosition = transform.position.y; 
        startingZRotation = transform.rotation.eulerAngles.z;
        startingXRotation = transform.rotation.eulerAngles.x;
        startingYRotation = transform.rotation.eulerAngles.y;
    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(startingXRotation, startingYRotation, startingZRotation + amplitude * Mathf.Sin(speed * Time.time));
        
    }

}
