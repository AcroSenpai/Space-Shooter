using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : ShipBehaviour
{
    public Animator anim;
    public ParticleSystem trailPS;
    public ParticleSystem explosionPS;
    public Sprite[] sprites;
    public RotateTransform rotate;
    public float minSpeed;
    public float maxSpeed;

    protected override void Start()
    {
        life = 4;
        base.Start();
    }

    protected override void HorizontalMovement()
    {
        if((direction.x < 0 && transform.position.x < -2.5f) || (direction.x > 0 && transform.position.x > 2.5f))
        {
            direction.y = -1;

            direction.x *= -1;
            return;
        }

        currentVelocity.x = direction.x * speed.x;
    }

    protected override void VerticalMovement()
    {
        if((direction.x < 0 && transform.position.x < -2.5f) || (direction.x > 0 && transform.position.x > 2.5f))
        {
            direction.y = 1;
            return;
        }

        currentVelocity.y = direction.y * speed.y;
    }

    public override void SetLife(int l)
    {
        anim.SetTrigger("Hit");
        
        base.SetLife(l);

    }
    private void DestroyShip()
    {
        GetComponent<Collider2D>().enabled = false;
        anim.SetTrigger("Explosion");
        gameManager.AddScore(20);
        isDead = true;
        Destroy(gameObject, 0.3f);
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

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerShip>().SetLife(hitDamage);
            Dead();
        }
    }
}