using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarToCamera : MonoBehaviour
{
    private Camera camera;
    
    private void Start()
    {
        camera = Camera.main;
    }

    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position, camera.transform.position);
    }
}
