using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerM : MonoBehaviour
{
    public GameObject objToSpawn;
    public float minTime;
    public float maxTime;
    public float deltaPosX;
    private float timeCounter;
    private float timeSpawn;

    // Use this for initialization
    void Start()
    {
        timeSpawn = minTime;
        timeCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeCounter >= timeSpawn)
        {
            Spawn();
        }
        else timeCounter += Time.deltaTime;
    }
    void Spawn()
    {
        timeCounter = 0;
        timeSpawn = Random.Range(minTime, maxTime);

        Vector2 spawnPos = transform.position;
        spawnPos.x += Random.Range(-deltaPosX, deltaPosX);

        GameObject obj = Instantiate(objToSpawn, spawnPos, Quaternion.identity);
        obj.name = objToSpawn.name + "_" + Time.time.ToString("00.00");
    }
}
