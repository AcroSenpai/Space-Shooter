using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EBullet : Bullet
{

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            transform.rotation = initRot;
            transform.position = iniPos;
            collision.gameObject.GetComponent<PlayerShip>().SetLife(damage);
        }
    }
}
