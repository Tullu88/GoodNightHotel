using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class WandererAI : MonoBehaviour
{
    [Header("Components")] 
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject sleepBar; //sleepBar, lockBar, sleepIcon, sleepBarSprite
    [SerializeField] private GameObject lockBar;
    [SerializeField] private GameObject sleepIcon;
    [SerializeField] private Image sleepBarSprite;

    [Header("Values")]
    public float maxSleep;
    public float scareCD;
    [SerializeField] private int minScarePoints;
    [SerializeField] private int maxScarePoints;

    [Header("Flags")]
    public bool isScared;

    private Transform[] floorPoints;
    private Transform[] roomPoints;
    private Transform exitPoint;
    
    private bool canBeScared = false;
    
    private float currentSleep;
    private float currentWake;
    private float rememberSleep;

    private int scareCount;
    
    private Transform currentPoint;

    private NavMeshAgent _agent;
    private AISpawner _aiSpawner;

    private bool pointReady;
    private bool usingFloor = false;
    private bool startSleeping = false;
    private bool startWaking = false;
    private bool isExiting;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _audioSource = GetComponent<AudioSource>();

        floorPoints = GameManager.instance.floorPoints;
        roomPoints = GameManager.instance.roomPoints;
        exitPoint = GameManager.instance.exitPoint;
        
        rememberSleep = maxSleep;
        currentWake = maxSleep;
        currentSleep = maxSleep;

        canBeScared = false;
        usingFloor = true;

        PickFloorPoint();
    }

    private void OnEnable()
    {
        GameManager.instance._spawner.validAI.Add(gameObject);
    }

    private void OnDestroy()
    {
        GameManager.instance._spawner.validAI.Remove(gameObject);
    }

    private void Update()
    {
        OnReadyPoint();
        CheckReachedPoint();
        UpdateSleep();
        UpdateWakeup();
        ResetFalseScare();
        UiLookAt();
    }
    void UiLookAt() {
        // sleepBar, lockBar, sleepIcon, sleepBarSprite
        sleepBar.transform.LookAt(Camera.main.transform);
        lockBar.transform.LookAt(Camera.main.transform);
        sleepIcon.transform.LookAt(Camera.main.transform);
        sleepBarSprite.transform.LookAt(Camera.main.transform);
    }
    

    private void ResetFalseScare()
    {
        if (isScared && !canBeScared)
        {
            isScared = false;
            Debug.LogWarning("Scare is being called on WandererAI but scare is not possible... No scare called!");
        }
    }

    private void CheckReachedPoint()
    {
        if (!_agent.pathPending)
        {
            if (_agent.remainingDistance <= _agent.stoppingDistance)
            {
                if (!_agent.hasPath || _agent.velocity.sqrMagnitude <= 0.1f)
                {
                    if (usingFloor)
                    {
                        usingFloor = false;
                        pointReady = false;

                        canBeScared = false;

                        currentPoint.GetComponent<PointGuardian>().inUse = false;
                        
                        PickRoomPoint();

                        return;
                    }

                    if (!startWaking && !startSleeping)
                    {
                        startSleeping = true;
                        sleepBar.SetActive(true);

                        canBeScared = true;

                        return;
                    }

                    if (isExiting)
                    {
                        Destroy(gameObject);
                    }
                    
                    _animator.ResetTrigger("walking");
                    _animator.SetTrigger("idle");
                }
            }
        }
    }

    private void UpdateSleep()
    {
        if(!startSleeping){ return;}

        if (currentSleep > 0)
        {

            if (isScared && canBeScared)
            {
                print("Scared");

                scareCount++;
                
                isScared = false; 
                canBeScared = false;

                var percent = currentSleep / maxSleep;
                var percentage = Mathf.RoundToInt(percent);
                
                if(percentage < .25){ print("Max Scare"); GameManager.instance.AddPoints(175); currentSleep += maxSleep; Invoke("ResetScareCD", scareCD); return;}
                
                print("Weak Scare");
                GameManager.instance.AddPoints(80);
                
                currentSleep += maxSleep / 2;

                Invoke("ResetScareCD", scareCD);
                
            }
            
            currentSleep -= Time.deltaTime;

            sleepBarSprite.fillAmount = currentSleep / maxSleep;
        }

        if (currentSleep <= 0)
        {
            sleepBar.SetActive(false);

            startWaking = true;
            startSleeping = false;
            canBeScared = false;

            sleepIcon.SetActive(true);
            
            if(scareCount <= 0){GameManager.instance.NoScareDamage(100f);}
        }
    }

    private void UpdateWakeup()
    {
        if(startSleeping){return;}
        if(!startWaking) {return;}

        if (currentWake > 0)
        {
            currentWake -= Time.deltaTime;
        }

        if (currentWake <= 0)
        {
            sleepIcon.SetActive(false);
            lockBar.SetActive(true);
            
            currentPoint.GetComponent<PointGuardian>().inUse = false;

            isExiting = true;

            currentPoint = exitPoint;
            
            _animator.ResetTrigger("idle");
            _animator.SetTrigger("walking");
        }
    }
    
    #region Point Type

    private void PickFloorPoint()
    {
        currentPoint = null;

        var index = Random.Range(0, floorPoints.Length);
        currentPoint = floorPoints[index];

        if (currentPoint.GetComponent<PointGuardian>().inUse)
        {
            pointReady = false;
            currentPoint = null;
            
            PickFloorPoint();
        }
        else
        {
            currentPoint.GetComponent<PointGuardian>().inUse = true;
            pointReady = true;
            
            _animator.ResetTrigger("idle");
            _animator.SetTrigger("walking");
        }
    }    
    
    private void PickRoomPoint()
    {
        currentPoint = null;
        
        var index = Random.Range(0, roomPoints.Length);
        currentPoint = roomPoints[index];

        if (currentPoint.GetComponent<PointGuardian>().inUse)
        {
            pointReady = false;
            currentPoint = null;
            
            PickRoomPoint();
        }
        else
        {
            currentPoint.GetComponent<PointGuardian>().inUse = true;
            pointReady = true;
            
            _animator.ResetTrigger("idle");
            _animator.SetTrigger("walking");
        }
    }

    #endregion

    private void ResetScareCD()
    {
        canBeScared = true;
    }

    private void OnReadyPoint()
    {
        if (pointReady)
        {
            _agent.SetDestination(currentPoint.position);
        }
    }
}
