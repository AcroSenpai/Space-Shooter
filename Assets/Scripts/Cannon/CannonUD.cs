using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonUD : Cannon
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
        c.GetBullet().Shot(transform.position, dir);
    }
}
