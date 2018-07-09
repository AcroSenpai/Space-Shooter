using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBoss : Cannon
{


    public override void ShotBullet(Cartridge c)
    {
        if(!canShot)
        {
            return;
        }
        dir = Vector2.down;
        canShot = false;
        timeCounter = 0;
        Vector2 posicion = transform.position;
        posicion.x = Random.Range(-2f, 2f);
        c.GetBullet().Shot(posicion, dir);
    }
}
