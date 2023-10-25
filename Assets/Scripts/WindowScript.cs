using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowScript : MonoBehaviour
{
    [SerializeField] private AudioSource windowOpen;
    [SerializeField] private AudioSource windowClose;
    // [SerializeField] private GameObject iconObject;
    [SerializeField] private AudioSource windAmdient;

    public bool isActive = false;

    void Start()
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        windowOpen = audioSources[0];
        windowClose = audioSources[1];
        windAmdient = audioSources[2];
    }

    public void PlaySounds()
    {
            // print("Window sound");
            if (isActive == false)
            {
                windowOpen.Play();
                windAmdient.time = 2f;
                windAmdient.Play();

                //StartCoroutine(PlayClip());

                isActive = true;
            } 
            else {
                windowClose.Play();
                windAmdient.Stop();
                isActive = false;
                //print("This is radio now off");
            }
    }
    
    private void StopAll()
    {
        windowClose.Play();
        windAmdient.Stop();
        //iconObject.SetActive(false);
        //print("This is radio now off");
    }

    // Stops the music from playing by itself after the clip ends
    private IEnumerator PlayClip()
    {
        yield return new WaitForSeconds(windAmdient.clip.length);
        StopAll();
    }
}
