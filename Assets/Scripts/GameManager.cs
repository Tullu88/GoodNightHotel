using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Components")] 
    [SerializeField] private GameObject shopObj;
    [SerializeField] private Light dayLight;
    public AISpawner _spawner;
    [SerializeField] private CinemachineFreeLook _cinema;
    [SerializeField] private GameObject shopUI;
    [SerializeField] private TextMeshProUGUI pointUI;

    [Header("Wander AI Components")]
    [Tooltip("Points in which the AI will wander first before finding a room to sleep in")]
    public Transform[] floorPoints;
    [Tooltip("Points in which the AI will find a room to sleep in")]
    public Transform[] roomPoints;
    [Tooltip("Point in which the AI will exit and destroy itself")]
    public Transform exitPoint;
    [Space]
    public Image insanityBar;

    [Header("Values")] 
    public float startingScarePoints;
    public float currentScarePoints;
    [Space]
    [SerializeField] private float dayLastTimer = 60f;
    [SerializeField] private float nightLastTimer = 60f;
    [Space]
    [SerializeField] private float currentDayTimer;
    [SerializeField] private float currentNightTimer;
    public int perk0Cost;
    public int perk1Cost;
    public int perk2Cost;

    [Header("Flags")] 
    [SerializeField] public bool isDay;
    [SerializeField] private bool isNight;
    [Space]
    public bool stopTimeCycle = false;

    public bool shopActive = false;
    [Space] 
    [SerializeField] private int dayCount;

    #region Singleton
    public static GameManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance);
        }
        else if (instance == null)
        {
            instance = this;

            currentScarePoints = startingScarePoints;
            
            currentDayTimer = dayLastTimer;
            
            currentNightTimer = nightLastTimer;

            isDay = true;
        }
    }
    #endregion

    #region UI

    
    public void NoScareDamage(float damage)
    {
        if(currentScarePoints <= 0){Debug.LogWarning("Player does not have enough scare points to take damage.."); return;}

        currentScarePoints -= damage;
        
        insanityBar.fillAmount = currentScarePoints / startingScarePoints ;

    }

    #endregion

    private void Update()
    {
        CursonManager();
        UpdateDayTimer();

        if(pointUI == null){return;}
        pointUI.text = currentScarePoints.ToString();

        if (currentScarePoints <= 0)
        {
            SceneManager.LoadScene(1);
        }
    }

    public void OpenShop()
    {
        print("Open Shop");
        shopUI.SetActive(true);
        shopActive = true;
    }

    public void CloseShop()
    {
        shopUI.SetActive(false);
        shopActive = false;
    }

    #region Perks

    public void PurchasePerk0()
    {
        if(currentScarePoints != perk0Cost) {return;}
        _spawner.perk0 = true;
    }    
    public void PurchasePerk1()
    {
        if(currentScarePoints != perk1Cost) {return;}
        _spawner.perk1 = true;
    }    
    public void PurchasePerk2()
    {
        if(currentScarePoints != perk2Cost) {return;}
        _spawner.perk2 = true;
    }

    #endregion

    public void AddPoints(int points)
    {
        // Add points to a ui element here <<<<<<<
        currentScarePoints += points;
    }
    
    private void UpdateDayTimer()
    {
        if(stopTimeCycle){return;}
        
        if (isDay)
        {
            if (shopObj != null)
            {
                shopObj.SetActive(true);  
                //shopObj.transform.position = new Vector3(-41.5999985f,3.27999997f,16.6100006f); 
            }

            currentDayTimer -= Time.deltaTime;

            if (currentDayTimer <= 0)
            {   //shopObj.transform.position = new Vector3(-41.5999985f,3.27999997f,16.6100006f);
                currentDayTimer = dayLastTimer;
                
                isDay = false;
                dayLight.enabled = false;

                _spawner.StartSpawns();
                
                isNight = true;
            }
        }        
        if (isNight)
        {
            if (shopObj != null)
            {
                shopObj.SetActive(false);   
            }

            currentNightTimer -= Time.deltaTime;

            if (currentNightTimer <= 0)
            {
                currentNightTimer = nightLastTimer;
                
                isNight = false;
                dayLight.enabled = true;
                
                _spawner.DisableSpawns();

                isDay = true;
            }
        }
    }

    private void CursonManager()
    {
        if(Input.GetMouseButtonDown(1)){return;}
        
        if (Input.GetMouseButton(1))
        {
            _cinema.enabled = true;
        }
        else
        {
            _cinema.enabled = false;
        }
    }
}
