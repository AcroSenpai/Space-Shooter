using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShooterShip : AIShipBase
{

    public WeaponE weapon;

    // Update is called once per frame
    void Update()
    {
           weapon.ShotWeapon();
    }

    public override void Inicialice()
    {
        base.Inicialice();
        weapon = GetComponentInChildren<WeaponE>();

    }
}
