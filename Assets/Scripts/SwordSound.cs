using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSound : MonoBehaviour
{
    [SerializeField] private AudioSource swordfall;
    bool collided = false;
    Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        rigidbody = GetComponent<Rigidbody>();
        swordfall = audioSources[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activateForce()
    {
        rigidbody.AddForce(Vector3.down * 9.8f * 27f, ForceMode.Acceleration);
    }

    void OnCollisionEnter(Collision collision) 
    {
        print("This is the collision: " + collision);
        if (collision.gameObject.tag == "Floor" && collided == false)
        {   
            swordfall.time = 0.1f;
            swordfall.Play();
            StartCoroutine(StopVelocity());
            collided = true;
        }
        StartCoroutine(StopVelocity());
    } 

    IEnumerator StopVelocity()
    {
        yield return new WaitForSeconds(swordfall.clip.length);
        rigidbody.velocity = Vector3.zero;
    }
    
}
