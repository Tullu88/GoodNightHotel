using System;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEngine;
using UnityEngine.AI;

public class AISpawner : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private GameObject aiPrefab;
    [SerializeField] private GameObject[] startSpawns;
    
    public List<GameObject> validAI = new List<GameObject>();
    public bool startSpawn;
    
    [Header("Values")] 
    public float timeTillSpawn;
    public int maxEntities;

    [Header("Flags")] 
    public bool perk0 = false;
    public bool perk1 = false;
    public bool perk2 = false;

    private int entityCount = 0;
    private float currentTimer;
    private bool spawnOne;

    private bool firstOne = false;

    private void Awake()
    {
        currentTimer = timeTillSpawn;
        firstOne = true;
    }

    public void IncreaseDifficulty()
    {
        if(maxEntities >= 12){return;}

        maxEntities++;
    }
    
    private void Update()
    {
        StartCoroutine(Spawn());
        SpawnTimer();
        UpdateChildCount();
    }

    public void StartSpawns()
    {
        startSpawn = true;
        IncreaseDifficulty();
    }    
    public void DisableSpawns()
    {
        startSpawn = false;
        foreach (var ai in validAI)
        {
            Destroy(ai);
        }
    }

    private void UpdateChildCount()
    {
        entityCount = transform.childCount;
    }

    private IEnumerator Spawn()
    {
        yield return new WaitUntil(() => spawnOne);
        var index = Random.Range(0, startSpawns.Length);
        var entity = Instantiate(aiPrefab, startSpawns[index].transform.position, Quaternion.identity);
        entity.transform.parent = gameObject.transform;
        entity.SetActive(true);
        spawnOne = false;

        entity.name = "Customer";
        
        if(perk0){UsePerk0(entity);}
        if(perk1){UsePerk1(entity);}
        if(perk2){UsePerk2(entity);}
    }

    private void UsePerk0(GameObject entity)
    {
        WandererAI ai = entity.GetComponent<WandererAI>();
        ai.maxSleep += ai.maxSleep;
    }
    private void UsePerk1(GameObject entity)
    {
        WandererAI ai = entity.GetComponent<WandererAI>();
        ai.scareCD = ai.scareCD / 2;
    }
    private void UsePerk2(GameObject entity)
    {
        NavMeshAgent ai = entity.GetComponent<NavMeshAgent>();
        ai.speed = ai.speed / 2;
    }

    private void SpawnTimer()
    {
        if(!startSpawn){return;}
        if(entityCount >= maxEntities){return;}

        currentTimer -= Time.deltaTime;

        if (currentTimer <= 0 || firstOne)
        {
            spawnOne = true;
            firstOne = false;
            currentTimer = timeTillSpawn;
        }
    }
}
