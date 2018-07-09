using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cartridge
{
    public int maxAmmo;
	protected Bullet[] bullets;
    protected int currentBullet = 0;

    public Cartridge(int mA, GameObject bulletPrefab, Transform ammoTransform, Vector3 position, string name)
    {
        maxAmmo = mA;
        bullets = new Bullet[maxAmmo];
        Vector3 spawnpos = position;

        
        for(int i = 0; i < bullets.Length; i++)
        {
            GameObject obj = GameObject.Instantiate(bulletPrefab, spawnpos, Quaternion.identity, ammoTransform);
            obj.name = name+ bulletPrefab.name + i;
            bullets[i] = obj.GetComponent<Bullet>();
            spawnpos.x -= 0.2f;
        }
    }


    public Bullet GetBullet()
    {

        Bullet b = bullets[currentBullet];

        currentBullet++;
        if(currentBullet >= maxAmmo)
        {
            currentBullet = 0;
        }

        return b;
    }

    ~Cartridge() { }

}
