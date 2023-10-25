using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitchActions : MonoBehaviour
{
    [SerializeField] private AudioSource lightOn;
    [SerializeField] private AudioSource lightOff;
    [SerializeField] private Light pointLight;

    public bool isActive = false;

    void Start()
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        lightOn = audioSources[0];
        lightOff = audioSources[1];

        pointLight = GetComponentInChildren<Light>();
        //windAmdient = audioSources[2];
    }

    public void Actions()
    {
            if (isActive == false)
            {
                lightOn.Play();
                pointLight.intensity = 0.56f;
                isActive = true;
            } 
            else {
                lightOff.Play();
                pointLight.intensity = 0;
                isActive = false;
            }
    }
}
