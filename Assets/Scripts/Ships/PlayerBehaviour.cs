using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public Vector2 speed;
    private Vector2 axis;

    private Vector2 currentVelocity; // Esto sera igual al axis * speed
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        HorizontalMovement();
        VerticalMovement();

        // Mover el player
        transform.Translate(currentVelocity * Time.deltaTime);
	}

    public void SetAxis(Vector2 newAxis)
    {
        axis = newAxis;
    }

    void HorizontalMovement()
    {
        if((axis.x < 0 && transform.position.x < -2.5f) || (axis.x > 0 && transform.position.x > 2.5f))
        {
            currentVelocity.x = 0;
            return;
        }

        currentVelocity.x = axis.x * speed.x;
    }

    void VerticalMovement()
    {
        if((axis.y < 0 && transform.position.y < -4.5f) || (axis.y > 0 && transform.position.y > 4.5f))
        {
            currentVelocity.y = 0;
            return;
        }

        currentVelocity.y = axis.y * speed.y;
    }
}
