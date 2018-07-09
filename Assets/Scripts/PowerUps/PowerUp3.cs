using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp3 : PowerUp
{
    // Use this for initialization


    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log(collision.GetComponent<PlayerShip>().life);
            collision.GetComponent<PlayerShip>().AddLife(1);
            Debug.Log(collision.GetComponent<PlayerShip>().life);
            DelPowerUp();
        }
    }


}
