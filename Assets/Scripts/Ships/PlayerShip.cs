using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : ShipBehaviour
{
    public Animator anim;
    private float Tiempo = 0f;
    public AudioSource SoundFX2;
    public AudioSource SoundFX3;
    public GameObject[] tails;
    protected override void Start()
    {
        canFly = true;

        base.Start();

        gameManager.PlayerLife(life);
    }

    protected override void Update()
    {
        base.Update();
        if(isDead)
        {
            Tiempo += Time.deltaTime;
            if (Tiempo > 2f)
            {
                Debug.Log("Hola");
                GameOver();
            }
            
        }
    }

    protected override void HorizontalMovement()
    {
        if((direction.x < 0 && transform.position.x < -2.5f) || (direction.x > 0 && transform.position.x > 2.5f))
         {
            currentVelocity.x = 0;
            return;
         }

        base.HorizontalMovement();
    }
    protected override void VerticalMovement()
    {
        if((direction.y < 0 && transform.position.y < -4.5f) || (direction.y > 0 && transform.position.y > 4.5f))
        {
            currentVelocity.y = 0;
            return;
        }

        base.VerticalMovement();
    }

    public override void SetLife(int l)
    {
        anim.SetTrigger("Hit");
        Debug.Log("man dao");
        base.SetLife(l);
        if (!isDead)
        {
            SoundFX.Play();
        }
        gameManager.PlayerLife(life);
        gameObject.GetComponentInChildren<Weapon>().PreviousWapon();
    }

    public void AddLife(int l)
    {
        life += l;
        SoundFX3.Play();
        anim.SetTrigger("Healt");      
        gameManager.PlayerLife(life);
    }

    protected override void Dead()
    {
        isDead = true;
        GetComponent<Collider2D>().enabled = !GetComponent<Collider2D>().enabled;
        for(int i = 0; i < tails.Length; i++)
        {
            tails[i].SetActive(false);
        }
        anim.SetTrigger("Explosion");
        SoundFX2.Play();
    }

    private void GameOver()
    {
        gameManager.GameOver();
    }
}