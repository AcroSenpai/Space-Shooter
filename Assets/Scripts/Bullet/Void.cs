using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Void : MonoBehaviour
{
    private float tiempo = 0f;
    private Vector2 targetPos;
    private Vector3 ufoPos;
    private Collider2D ufo;
    private void Update()
    {
        tiempo += Time.deltaTime;
        if(tiempo > 1f)
        {
            if(ufo != null) ufo.GetComponent<ShipBehaviour>().direction = Vector2.down;
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "UFO")
        {
            //collision.GetComponent<ShipBehaviour>().currentVelocity = Vector2.up;
            //collision.GetComponent<ShipBehaviour>().direction = Vector2.up;

            //collision.GetComponent<ShipBehaviour>().speed = Vector2.zero;
            ufoPos = collision.transform.position;
            targetPos = ufoPos - transform.position;
            targetPos.Normalize();
            ufo = collision;
            ufo.GetComponent<ShipBehaviour>().direction = targetPos;
        }
    }
}
