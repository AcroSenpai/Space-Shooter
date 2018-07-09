using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Green : Bullet
{
    public Cannon cannon;
    public Weapon weapon;
    private Cartridge[] cartridge;
    public GameObject bullet;
    public Transform ammoTransform;
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "UFO")
        {
            if (transform.position.y < 4.5f && transform.position.y > -4.5f)
            {
                ShipBehaviour E = collision.gameObject.GetComponent<ShipBehaviour>();
                E.SetLife(damage);
                weapon = GameObject.FindGameObjectWithTag("weapons").GetComponent<Weapon>();
                ammoTransform = GameObject.Find("Ammo").GetComponent<Transform>();
                cartridge = weapon.GetCartridge();
                cannon.ShotBullet(cartridge[0]);
                transform.rotation = initRot;
                transform.position = iniPos;
            }
         
        }
    }
}
