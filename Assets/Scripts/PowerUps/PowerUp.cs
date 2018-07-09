using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public Weapon weapon;
    // Use this for initialization
    void Start()
    {
        weapon = GameObject.FindGameObjectWithTag("weapons").GetComponent<Weapon>();
    }

    private void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime, Space.World);
    }

    public void SetCannon()
    {
        weapon.NextWapon();
    }

    public void DelPowerUp()
    {
        Destroy(gameObject);
    }


    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<PlayerShip>().AddLife(1);
            SetCannon();
            DelPowerUp();
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Boundary")
        {
            DelPowerUp();
        }
    }

}
