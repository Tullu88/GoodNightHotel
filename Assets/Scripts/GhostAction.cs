using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAction : MonoBehaviour
{
     [SerializeField] private AudioSource howl;

     public bool isActive = false;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        howl = audioSources[0]; 
    }

    // Update is called once per frame
    void Update()
    {
        howl.Play();
    }
    
    public void PlaySound() {

    }
    
    }
