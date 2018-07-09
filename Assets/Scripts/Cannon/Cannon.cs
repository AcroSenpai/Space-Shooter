using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public float cooldown;
    protected float timeCounter;
    protected bool canShot = false;
    protected Vector2 dir;
	// Use this for initialization
	void Start ()
    {
        canShot = true;
        timeCounter = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(!canShot)
        {
            timeCounter += Time.deltaTime;
            if(timeCounter >= cooldown)
            {
                canShot = true;
            }
        }
    }



    public virtual void ShotBullet(Cartridge c)
    {
        if (!canShot)
        {
            return;
        }

        canShot = false;
        timeCounter = 0;
        dir = Vector2.up;
        c.GetBullet().Shot(transform.position, dir);

    }
}
