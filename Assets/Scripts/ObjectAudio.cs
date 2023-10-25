// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class ObjectAudio : MonoBehaviour
// {
//     // [SerializeField] private AudioSource radioOn;
//     // [SerializeField] private AudioSource radioSound;
//     // [SerializeField] private AudioSource radioOff;

//     void Start()
//     {
//         // AudioSource[] audioSources = GetComponents<AudioSource>();
//         // radioSound = audioSources[0];   
//         // radioOn = audioSources[1];
//         // radioOff = audioSources[2];

//         // audioManager = GetComponent<AudioManager>();

//     }

//     public void PlaySounds(string objectName, bool actionActivated)
//     {
//         switch (objectName)
//         {
//             // RADIO
//             case "Radio":
//             if (actionActivated == true)
//             {
//                 radioSound.Play();
//                 radioOn.Play();
//                 actionActivated = false;
//             } else {
//                 radioOff.Play();
//                 radioSound.Stop();
//                 actionActivated = true;
//                 print("This is radio now off");
//             }
//             break;

//             // CHAIR
//             // Probably don't need a stop function here
//             //make it so that the chair stops after the loop is over
//             case "Chair":
//             if (actionActivated == true)
//             {
//                 //chairNoise.Play();
//                 actionActivated = false;
//             } else {
//                 //chair.Stop();
//                 actionActivated = true;
//                 print("This is radio now off");
//             }
//             break;


//             // TO BE CODED!
//             case "Window":
//             if (actionActivated == true)
//             {
//                 //chairNoise.Play();
//                 actionActivated = false;
//             } else {
//                 //chair.Stop();
//                 actionActivated = true;
//                 print("This is radio now off");
//             }
//             break;

//             case "Weapon":
//             if (actionActivated == true)
//             {
//                 //chairNoise.Play();
//                 actionActivated = false;
//             } else {
//                 //chair.Stop();
//                 actionActivated = true;
//                 print("This is radio now off");
//             }
//             break;

//             case "WeaponSet":
//             if (actionActivated == true)
//             {
//                 //chairNoise.Play();
//                 actionActivated = false;
//             } else {
//                 //chair.Stop();
//                 actionActivated = true;
//                 print("This is radio now off");
//             }
//             break;

//             case "Faucet":
//             if (actionActivated == true)
//             {
//                 //chairNoise.Play();
//                 actionActivated = false;
//             } else {
//                 //chair.Stop();
//                 actionActivated = true;
//                 print("This is radio now off");
//             }
//             break;

//             case "Door":
//             if (actionActivated == true)
//             {
//                 //chairNoise.Play();
//                 actionActivated = false;
//             } else {
//                 //chair.Stop();
//                 actionActivated = true;
//                 print("This is radio now off");
//             }
//             break;

//             case "Shower":
//             if (actionActivated == true)
//             {
//                 //chairNoise.Play();
//                 actionActivated = false;
//             } else {
//                 //chair.Stop();
//                 actionActivated = true;
//                 print("This is radio now off");
//             }
//             break;

//             case "LightSwitch":
//             if (actionActivated == true)
//             {
//                 //chairNoise.Play();
//                 actionActivated = false;
//             } else {
//                 //chair.Stop();
//                 actionActivated = true;
//                 print("This is radio now off");
//             }
//             break;

//             default:
//             break;
//         }
//     }
// }
