using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShip : ShipBehaviour
{
    public Animator anim;
    public ParticleSystem trailPS;
    public ParticleSystem explosionPS;
    public Sprite[] sprites;
    public RotateTransform rotate;
    public float minSpeed;
    public float maxSpeed;

    public GameObject objToSpawn;
    public GameObject objToSpawn2;
    public GameObject objToSpawn3;
    protected override void Start()
    {
        life = 100;
        base.Start();
    }

    protected override void HorizontalMovement()
    {
        if((direction.x < 0 && transform.position.x < -2.5f) || (direction.x > 0 && transform.position.x > 2.5f))
         {
            direction.x *= -1;
            return;
         }

        base.HorizontalMovement();
    }
    protected override void VerticalMovement()
    {
        if(transform.position.y < 2.9f)
        {
            canFly = false;
            return;
        }

        base.VerticalMovement();
    }

    private void DestroyShip()
    {
        GetComponent<Collider2D>().enabled = false;
        SpawnPU();
        anim.SetTrigger("explosion");
        gameManager.AddScore(100);
        isDead = true;
        Destroy(gameObject, 1.5f);
    }
    protected override void Dead()
    {
        base.Dead();
        canFly = false;
        //rotate.SetCanRotate(false);
        DestroyShip();
    }

    public override void resetShip()
    {
        Destroy(gameObject);
    }

    protected void SpawnPU()
    {
        int rand = Random.Range(0, 3);
        Vector2 spawnPos = transform.position;
        if(rand == 1)
        {
            Instantiate(objToSpawn, spawnPos, Quaternion.identity);
        }
        else if(rand == 2)
        {
            Instantiate(objToSpawn2, spawnPos, Quaternion.identity);
        }
        else
        {
            Instantiate(objToSpawn3, spawnPos, Quaternion.identity);
        }
       
    }
}