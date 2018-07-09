using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShipBase : MonoBehaviour {

    public ShipBehaviour enemy;
    public Vector2 direction;

    // Use this for initialization
    void Start()
    {
        Inicialice();
    }


    public virtual void Inicialice()
    {
        direction.x = Random.Range(-direction.x, direction.x);
        enemy = GetComponent<ShipBehaviour>();
        enemy.SetAxis(direction);
        enemy.SetFly(true);
    }
}
