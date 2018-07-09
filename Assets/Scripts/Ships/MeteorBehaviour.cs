using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorBehaviour : ShipBehaviour
{
    public Animator anim;
    public ParticleSystem trailPS;
    public ParticleSystem explosionPS;
    public Sprite[] sprites;
    private RotateTransform rotate;
    private float minSpeed = 1;
    private float maxSpeed = 1;
    private int score = 10;


    protected override void Start()
    {
        speed.y = Random.Range(minSpeed, maxSpeed);
        rotate = GetComponent<RotateTransform>();
        rotate.SetCanRotate(true);
        life = 4;
        base.Start();
        anim.enabled = false;
        rend.sprite = sprites[0];
    }

    private void DestroyMeteor()
    {
        GetComponent<Collider2D>().enabled = false;
        anim.enabled = true;
        anim.SetTrigger("Death");
        explosionPS.Play();
        trailPS.Stop();
        gameManager.AddScore(score);
       // gameManager.SpawnPU(transform.position);
        Destroy(gameObject, 0.3f);
    }

    public override void SetLife(int l)
    {
        base.SetLife(l);
        if(life == 3)
        {
            rend.sprite = sprites[1];
        }
        if(life == 2)
        {
            rend.sprite = sprites[1];
        }
        else if(life == 1)
        {
            rend.sprite = sprites[2];
        }
    }

    protected override void Dead()
    {
        base.Dead();
        canFly = false;
        rotate.SetCanRotate(false);
        DestroyMeteor();
    }

    public override void resetShip()
    {
        Destroy(gameObject);
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerShip>().SetLife(hitDamage);
            Dead();
        }
    }



}
