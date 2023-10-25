using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Clips")]
    private AudioClip radioOn;
    private AudioClip radioSound;
    private AudioClip radioOff;
    private AudioClip chairNoise3;
    private AudioClip chairNoise2;
    private AudioClip chairNoise1;
    private AudioClip swordFall1;
    private AudioClip swordFall2;
    private AudioClip swordFall3;
    private AudioClip sinkFaucet;
    private AudioClip doorSqueakyOpen;
    private AudioClip doorSqueakyClose;
    private AudioClip doorOpen;
    private AudioClip doorClose;
    private AudioClip shower;
    private AudioClip switchOn;
    private AudioClip switchOff;
    [Header("Values")]
    
    #region Singleton
    public static AudioManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance);
        }
        else if (instance == null)
        {
            instance = this;

        }
    }
    #endregion
}
