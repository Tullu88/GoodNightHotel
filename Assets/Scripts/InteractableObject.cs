using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractableObject : MonoBehaviour
{
    TextMeshPro tooltip;
    bool actionActivated = false;
    private RadioScript radioScript;
    private ChairAudio chairScript;
    private WindowScript windowScript;
    private LightSwitchActions lightSwitchActions;
    private WeaponAction weaponAction;
    private DoorScript doorScript;
    public GameObject player;

    public GhostAction playerScript;
    

    // [SerializeField] private GameObject iconObject;
    // IconScript iconScript;

    void Awake()
    {
        tooltip = GetComponentInChildren<TextMeshPro>();
    }

    void Start()
    {
        radioScript = GetComponentInChildren<RadioScript>();
        chairScript = GetComponentInChildren<ChairAudio>();
        windowScript = GetComponentInChildren<WindowScript>();
        lightSwitchActions = GetComponentInChildren<LightSwitchActions>();
        weaponAction = GetComponentInChildren<WeaponAction>();
        doorScript = GetComponentInChildren<DoorScript>();

        playerScript = player.GetComponentInChildren<GhostAction>();
    }

    public void Interact() 
    {   
        print("Interact");
        if (actionActivated == false)
        {
            print("Action activated");
            actionActivated = true;
            ActivationAction();
            return;

        } 
        else if (actionActivated == true)
        {
            print("Action DEactivated");
             actionActivated = false;
             ActivationAction();
             return;
        }
        
    }

    void ActivationAction()
    {
        switch (this.name)
        {
            case "InteracatableObject":
            if (actionActivated == true)
            {
                print("This is a washing machine reaction");
            } else {
                print("This is a washing machine is now off");
            }
            break;
            
            case "RuinShop":
                if (actionActivated)
                {
                    GameManager.instance.OpenShop();
                }
                else
                {
                    GameManager.instance.CloseShop();
                }
                break;
            case "Customer":
                if (actionActivated == true)
                { 
                    playerScript.PlaySound();
                    WandererAI ai = GetComponent<WandererAI>();
                    ai.isScared = true;
                } else {
                    return;
                }
                break;

            // RADIO
            case "Radio":
            if (actionActivated == true)
            {   
                // iconObject.SetActive(true);
                radioScript.PlaySounds();
                GetComponentInChildren<GetCustomer>().TryToScare();
            } else {
                // iconObject.SetActive(false);
                radioScript.PlaySounds();
                GetComponentInChildren<GetCustomer>().TryToScare();
            }
            break;
            
            case "Candle":
                if (actionActivated)
                {
                    GetComponentInChildren<Light>().enabled = false;
                    GetComponentInChildren<GetCustomer>().TryToScare();
                }
                else
                {
                    GetComponent<Light>().enabled = false;
                }
                break;

            // CHAIR
            case "Chair":
                chairScript.StartActions();
                GetComponentInChildren<GetCustomer>().TryToScare();
            break;

            // WINDOW
            case "Window":
                if (actionActivated)
                {
                    Animator anim = GetComponent<Animator>();
                    anim.SetBool("Open", true);
                    GetComponentInChildren<GetCustomer>().TryToScare();   
                }
                else
                {
                    Animator anim = GetComponent<Animator>();
                    anim.SetBool("Open", false);
                }
                break;

            // LIGHT SWITCH
            case "LightSwitch":
                lightSwitchActions.Actions();
                GetComponentInChildren<GetCustomer>().TryToScare();
            break;

            // WEAPON
            case "Weapon":
                    weaponAction.Actions();
                    GetComponentInChildren<GetCustomer>().TryToScare();
            break;

            case "WeaponSet":
                if (actionActivated == true)
                {
                    //chairNoise.Play();
                    actionActivated = false;
                } else {
                    //chair.Stop();
                    actionActivated = true;
                    print("This is radio now off");
                }
            break;

            case "Faucet":
                if (actionActivated == true)
                {
                    //chairNoise.Play();
                    actionActivated = false;
                } else {
                    //chair.Stop();
                    actionActivated = true;
                    print("This is radio now off");
                }
            break;

            case "door":
                if (actionActivated)
                {
                    Animator animator = GetComponent<Animator>();
                    doorScript.PlaySounds();
                    animator.SetBool("swing", true);
                    GetComponentInChildren<GetCustomer>().TryToScare();
                }
                else
                {
                    Animator animator = GetComponent<Animator>();
                    doorScript.PlaySounds();
                    animator.SetBool("swing", false);
                    GetComponentInChildren<GetCustomer>().TryToScare();
                }
                break;

            case "Shower":
                if (actionActivated == true)
                {
                    //chairNoise.Play();
                    actionActivated = false;
                } else {
                    //chair.Stop();
                    actionActivated = true;
                    print("This is radio now off");
                }
                break;
            
            default:
            break;
        }
    }
    
}
