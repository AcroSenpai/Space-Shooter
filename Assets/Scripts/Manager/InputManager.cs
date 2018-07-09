using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public PlayerShip player;
    public Weapon weapon;
    private GameManager GameM;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShip>();
        weapon = GameObject.FindGameObjectWithTag("weapons").GetComponent<Weapon>();
        GameM = GetComponent<GameManager>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if(GameM.gamePause) GameM.Resume();
            else GameM.Pause();
        }

        if(GameM.gamePause) return;

        Vector2 inputAxis = Vector2.zero;
        inputAxis.x = Input.GetAxis("Horizontal");
        inputAxis.y = Input.GetAxis("Vertical");
        player.SetAxis(inputAxis);

        if (Input.GetButton("Fire1"))
        {
            weapon.ShotWeapon();
        }
    }
}
