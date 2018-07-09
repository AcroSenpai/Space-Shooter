using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    private enum SpawnActive { metheor, ships, boss};
    private SpawnActive spawnActive;

    private int score;
    public GameObject spawn1, spawn2, spawn3;

    int value = 0;
    private float Tiempo = 0.0f, ctiempo;
    private bool contador = false;
    private bool spawn = false;

    // Use this for initialization
    void Start ()
    {
        spawn1 = GameObject.FindGameObjectWithTag("Spawner1");
        spawn1.SetActive(true);
        /*spawn2 = GameObject.FindGameObjectWithTag("Spawner2");
        spawn2.SetActive(false);
        spawn3 = GameObject.FindGameObjectWithTag("Spawner3");
        spawn3.SetActive(false);*/
        Tiempo = 0.0f;
    }

    private void Update()
    {
        if(contador)
        {
            Tiempo += Time.deltaTime;
            
            if (Tiempo >= ctiempo)
            {
                spawn = true;
                Tiempo = 0f;
                SpawnA();
                contador = false;
            }
            
        }
    }


    public void GetScore(int nscore)
    {
        //score = nscore;
        value += nscore;
        SpawnA();

    }

    private void SpawnA()
    {
        switch (spawnActive)
        {
            case SpawnActive.metheor:
                if (value > 100)
                {
                    ctiempo = 3f;
                    contador = true;
                    SetShip();
                }
                break;
            case SpawnActive.ships:
                if (value > 300)
                {
                    ctiempo = 5f;
                    contador = true;
                    SetBoss();
                }
                break;
            case SpawnActive.boss:
                if (value > 400)
                {
                    ctiempo = 4f;
                    contador = true;
                    SetMetheor();
                }

                break;
            default:
                break;
        }
    }

    void SetMetheor()
    {
        spawn2.SetActive(false);
        spawn3.SetActive(false);
        if (spawn)
        {
            value = 0;
            spawn1.SetActive(true);
            spawn2.SetActive(false);
            spawn3.SetActive(false);
            spawnActive = SpawnActive.metheor;
            spawn = false;
        } 
    }

    void SetShip()
    {
        spawn1.SetActive(false);
        spawn3.SetActive(false);
        if (spawn)
        {
            spawn2.SetActive(true);
            spawn1.SetActive(false);
            spawn3.SetActive(false);
            spawnActive = SpawnActive.ships;
            spawn = false;
        }
    }
    void SetBoss()
    {
        spawn1.SetActive(false);
        spawn2.SetActive(false);
        if (spawn)
        {
            spawn3.SetActive(true);
            spawn3.GetComponent<SpawnerB>().Spawn();
            spawn1.SetActive(false);
            spawn2.SetActive(false);
            spawnActive = SpawnActive.boss;
            spawn = false;
        }

    }


}
