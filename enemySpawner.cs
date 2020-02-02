using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public float minSpawnTime = 3.0f;
    public float maxSpawnTime = 5.0f;
    public float distFromCamera = 10.0f;

    public GameObject enemyPrefab;

    private float timer = 0.0f;
    private float nextTime;


    void Start()
    {
        nextTime = Random.Range(minSpawnTime, maxSpawnTime);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > nextTime)
        {
            Vector3 pos = new Vector3(Random.value, Random.value, 10);
            pos = Camera.main.ViewportToWorldPoint(pos);

            Instantiate(enemyPrefab, pos, Quaternion.identity);


            Debug.Log("Object created");
            if(maxSpawnTime > 1.5)
            {
                maxSpawnTime -= .1f;
            }
            if(minSpawnTime > 0)
            {
                minSpawnTime -= .1f;
            }
            
            
            timer = 0.0f;
            nextTime = Random.Range(minSpawnTime, maxSpawnTime);
        }
    }
}

