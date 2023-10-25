using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioScript : MonoBehaviour
{
    [SerializeField] private AudioSource radioOn;
    [SerializeField] private AudioSource radioSound;
    [SerializeField] private AudioSource radioOff;
    [SerializeField] private GameObject iconObject;

    public bool isActive = false;

    void Start()
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        radioSound = audioSources[0];   
        radioOn = audioSources[1];
        radioOff = audioSources[2];
    }

    public void PlaySounds()
    {
            if (isActive == false)
            {
                radioSound.Play();
                radioOn.Play();

                StartCoroutine(PlayClip());

                isActive = true;
            } 
            else {
                radioOff.Play();
                radioSound.Stop();
                isActive = false;
                print("This is radio now off");
            }
    }

    private void StopAll()
    {
        radioOff.Play();
        radioSound.Stop();
        iconObject.SetActive(false);
        //print("This is radio now off");
    }

    // Stops the music from playing by itself after the clip ends
    private IEnumerator PlayClip()
    {
        yield return new WaitForSeconds(radioSound.clip.length);
        StopAll();
    }
}
