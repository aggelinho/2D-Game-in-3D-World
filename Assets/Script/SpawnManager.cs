using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;    
    public GameObject obstacle2Prefab;   
    public GameObject platformPrefab;   
    public GameObject enemyPrefab;  
    public GameObject finishPointPrefab;     

    private float spawnX = 12f;
    private float spawnZ = -1.64f;

    private float startDelay = 2f;
    private float repeatRate = 4f;

    private PlayerController playercontroller;
    private float finishSpawnTime = 60f; 
    private bool finishSpawned = false;
    private float timer = 0f;
    void Start()
    {
        playercontroller = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObject", startDelay, repeatRate);
    }

    void Update()
    {
        if (playercontroller.gameOver) return;
        timer += Time.deltaTime;

        if (!finishSpawned && timer >= finishSpawnTime)
    {
      SpawnFinishPoint();
      finishSpawned = true;
    }
    }

    void SpawnObject()
    {
        if (playercontroller.gameOver) return;

        float randomChoice = Random.value;

        // Πιθανότητα εμφάνισης εμποδίου 1
        if (randomChoice < 0.4f)
        {
            Vector3 pos = new Vector3(spawnX, 0.5f, spawnZ);
            Instantiate(obstaclePrefab, pos, obstaclePrefab.transform.rotation);
        }
        // Πιθανότητα εμφάνισης εμποδίου 2
        else if (randomChoice < 0.6f)
        {
            Vector3 pos = new Vector3(spawnX, 0.5f, spawnZ);
            Instantiate(obstacle2Prefab, pos, obstacle2Prefab.transform.rotation);
        }
        // Πιθανότητα εμφάνισης πλατφόρμας
        else
        {
            float platformY = Random.Range(1.5f, 3.0f);
            Vector3 platformPos = new Vector3(spawnX, platformY, spawnZ);

            Instantiate(platformPrefab, platformPos, platformPrefab.transform.rotation);

            // Πιθανότητα να εμφανιστεί enemy πάνω στην πλατφόρμα 
            if (Random.value > 0.4f)
            {
                float enemyOffsetY = 0.5f; 
                Vector3 enemyPos = new Vector3(spawnX, platformY + enemyOffsetY, spawnZ);

                Instantiate(enemyPrefab, enemyPos, enemyPrefab.transform.rotation);
            }
        }
    }

    void SpawnFinishPoint()
    {
        float finishY = Random.Range(0.8f, 2.5f);

        Vector3 finishPos = new Vector3(spawnX, finishY, spawnZ);

        Instantiate(finishPointPrefab, finishPos, finishPointPrefab.transform.rotation);

        Debug.Log("Finish Point appeared!");
    }    
}
