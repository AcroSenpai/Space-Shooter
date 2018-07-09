using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBehaviour : MonoBehaviour
{
    public Vector2 speed;
    public Vector2 direction;
    public Vector2 currentVelocity;
    public Vector2 iniPos;
    public float time = 10.0f;

    public int life;
    public int initlife;
    public int hitDamage = 1;

    public SpriteRenderer rend;

    public bool canFly = false;
    protected bool isDead;

    protected GameManager gameManager;
    public AudioSource SoundFX;
    // Use this for initialization
    protected virtual void  Start ()
    {
        iniPos = transform.position;
        initlife = life;
        rend = GetComponentInChildren<SpriteRenderer>();
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }
	
	// Update is called once per frame
	protected virtual void Update ()
    {
        if(!canFly) return;

        HorizontalMovement();
        VerticalMovement();

        // Mover el player
        transform.Translate(currentVelocity * Time.deltaTime, Space.World);
    }

    public void SetAxis(Vector2 newAxis)
    {
        direction = newAxis;
    }

    protected virtual void HorizontalMovement()
    {
        currentVelocity.x = direction.x * speed.x;
    }

    protected virtual void VerticalMovement()
    {
        currentVelocity.y = direction.y * speed.y;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (isDead)
        {
            return;
        }
        if (collision.tag == "Boundary")
        {
            Resetear(collision);
        }
    }


    public virtual void OnTriggerEnter2D(Collider2D collision)
    {

    }



    public virtual void SetLife(int l)
    {
        life -= l;
        if (life <= 0)
        {
            life = 0;
            Dead();

        }
    }

    protected virtual void Dead()
    {
        isDead = true;
        if (SoundFX != null)
        {
            SoundFX.pitch = Random.Range(0.97f, 1.23f);
            SoundFX.volume = Random.Range(0.97f, 1.23f);
            SoundFX.Play();
        }
    }

    public virtual void resetShip()
    {

    }
    public void SetFly(bool f)
    {
        canFly = f;
    }

    public bool GetFly()
    {
        return canFly;
    }


    public void Resetear(Collider2D collision)
    {
        if(collision.tag == "Boundary")
        {
            transform.position = iniPos;
            life = initlife;
            canFly = false;
            resetShip();
        }
    }
}
