using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5;
    public int damage = 1;

    protected bool shot = false;
    protected Vector2 iniPos, dir, rotate;
    protected Quaternion initRot;
    public AudioSource SoundFX;
    public AudioSource SoundFX2;

    // Use this for initialization
    void Start ()
    {
        iniPos = transform.position;
        initRot = transform.rotation;
        damage = 1;
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(shot)
        {
            transform.Translate(dir * speed * Time.deltaTime);
        }
	}

    public virtual void Shot(Vector2 origin, Vector2 direccion)
    {
        shot = true;
        dir = direccion;
        transform.position = origin;

        if(SoundFX != null)
        {
            SoundFX.pitch = Random.Range(0.97f, 1.23f);
            SoundFX.volume = Random.Range(0.97f, 1.23f);
            SoundFX.Play();
        }
    }

    public virtual void Shot(Vector2 origin, Vector2 direccion, float zRot)
    {
        Shot(origin, direccion);
        transform.rotation = Quaternion.Euler(0, 0, zRot);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Reseteo(collision);
    }

    protected virtual void Reseteo(Collider2D collision)
    {
        if(collision.tag == "Boundary")
        {
            shot = false;
            transform.rotation = initRot;
            transform.position = iniPos;
        }
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "UFO")
        {
            if ( transform.position.y < 4.5f &&  transform.position.y > -4.5f)
            {
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
