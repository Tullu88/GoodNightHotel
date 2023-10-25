using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] private AudioSource doorClose;
    [SerializeField] private AudioSource doorOpen;

    public bool isActive = false;

    void Start()
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        doorOpen = audioSources[0];   
        doorClose = audioSources[1];
    }

    public void PlaySounds()
    {
            if (isActive == false)
            {
                doorOpen.Play();

                isActive = true;
            } 
            else {
                doorClose.Play();
                isActive = false;
                print("The door is closed");
            }
    }
}
