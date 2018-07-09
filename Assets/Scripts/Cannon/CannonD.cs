using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonD : Cannon
{

    public override void ShotBullet(Cartridge c)
    {
        if(!canShot)
        {
            return;
        }
        dir = Vector2.up;
        canShot = false;
        timeCounter = 0;
        c.GetBullet().Shot(transform.position - new Vector3(0.1f,0,0), dir);

        c.GetBullet().Shot(transform.position + new Vector3(0.1f, 0, 0), dir);

    }
}
