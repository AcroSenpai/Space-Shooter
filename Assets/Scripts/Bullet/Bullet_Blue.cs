using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Blue : Bullet
{
    public GameObject objToSpawn;
    void Start()
    {
        iniPos = transform.position;
    }
    // Update is called once per frame
    void Update ()
    {
        if(shot)
        {
            transform.Translate(dir * speed * Time.deltaTime);
            //transform.Rotate(new Vector3(100, 100, 0) * speed * Time.deltaTime);
        }
    }

    public override void Shot(Vector2 origin, Vector2 direccion)
    {
        base.Shot(origin, direccion);
    }
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "UFO")
        {
            if (transform.position.y < 4.5f && transform.position.y > -4.5f)
            {
                Vector2 spawnPos = transform.position;
                Instantiate(objToSpawn, spawnPos, Quaternion.identity);
                transform.rotation = initRot;
                transform.position = iniPos;
                ShipBehaviour E = collision.gameObject.GetComponent<ShipBehaviour>();
                E.SetLife(damage);
               

                if (SoundFX != null)
                {
                    SoundFX2.pitch = Random.Range(0.97f, 1.23f);
                    SoundFX2.volume = Random.Range(0.97f, 1.23f);
                    SoundFX2.Play();
                }
            }

        }
    }
}
