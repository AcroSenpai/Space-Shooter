using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerB : MonoBehaviour
{
    public GameObject objToSpawn;
    public float deltaPosX;

    // Update is called once per frame
    public void Spawn()
    { 
        Vector2 spawnPos = transform.position;
        spawnPos.x += Random.Range(-deltaPosX, deltaPosX);
        Instantiate(objToSpawn, spawnPos, Quaternion.identity);
    }
}
