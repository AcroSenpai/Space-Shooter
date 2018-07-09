using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp2 : PowerUp
{
    // Use this for initialization

    public void SetCartridge()
    {
        weapon.NextBullet();
    }


    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<PlayerShip>().AddLife(0);
            SetCartridge();
            DelPowerUp();
        }
    }


}
