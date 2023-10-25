using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairAudio : MonoBehaviour
{
    [SerializeField] private AudioSource chairNoise1;
    [SerializeField] private AudioSource chairNoise2;
    [SerializeField] private AudioSource chairNoise3;

    public bool isActive = false;

    float amplitude = 5f;
    float speed = 20f;

    float startingXPosition;
    float startingYPosition;
    float startingZPosition;

    bool move1 = false;
    bool move2 = false;
    bool move3 = false;

    [SerializeField] private GameObject IconObject;

    void Start()
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        chairNoise1 = audioSources[0];   
        chairNoise2 = audioSources[1];
        chairNoise3 = audioSources[2];

        
    }

    void UpdatePosition()
    {
        startingXPosition = transform.parent.position.x;
        startingYPosition = transform.parent.position.y;
        startingZPosition = transform.parent.position.z;
    } 

    void Update()
    {
        if (move1)
        {   
            UpdatePosition();
            float newZPosition = startingZPosition + amplitude * (speed * Time.deltaTime);
            transform.parent.position = Vector3.Lerp (transform.parent.position, new Vector3(startingXPosition, startingYPosition, newZPosition), Time.deltaTime);
        } else if (move2)
        {
            UpdatePosition();
            float newZPosition = startingZPosition - amplitude * (speed * Time.deltaTime);
            float newXPosition = startingXPosition + amplitude * (speed * Time.deltaTime);
            transform.parent.position = Vector3.Lerp (transform.parent.position, new Vector3(newXPosition, startingYPosition, startingZPosition), Time.deltaTime);
        } else if (move3)
        {
            float newZPosition = startingZPosition - amplitude * (speed * Time.deltaTime);
            float newXPosition = startingXPosition - amplitude * (speed * Time.deltaTime);
            transform.parent.position = Vector3.Lerp (transform.parent.position, new Vector3(newXPosition, startingYPosition, newZPosition), Time.deltaTime);
            
        }
    }

    // public void Movement()
    // {
    //     if (isActive == false) 
    //     {
    //         StartCoroutine(StartMovement());
    //         isActive = true;
    //     } else {
    //         return;
    //     }
        
    // }

    public void StartActions()
    {
        if (isActive == false) 
        {
            StartCoroutine(StartMovement());
            StartCoroutine(PlayClips());
            isActive = true;
        } else {
            return;
        }
    }

    IEnumerator StartMovement()
    {   
        IconObject.SetActive(true);
        move1 = true;
        yield return new WaitForSeconds(chairNoise1.clip.length);
        move1 = false;
        move2 = true;
        yield return new WaitForSeconds(chairNoise1.clip.length);
        move2 = false;
        move3 = true;
        yield return new WaitForSeconds(chairNoise1.clip.length + .5f);
        move3 = false;
        IconObject.SetActive(false);
    }

    // public void PlaySounds()
    // {
    //     if (isActive == false) 
    //     {
    //         StartCoroutine(PlayClips());
    //         isActive = true;
    //     } else {
    //         return;
    //     }
        
    // }

    private IEnumerator PlayClips()
    {
        chairNoise1.Play();
        yield return new WaitForSeconds(chairNoise1.clip.length);
        chairNoise2.Play();
        yield return new WaitForSeconds(chairNoise2.clip.length);
        chairNoise3.Play();
        yield return new WaitForSeconds(chairNoise3.clip.length);
        isActive = false;
    }
}

