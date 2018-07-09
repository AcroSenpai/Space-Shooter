using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTransform : MonoBehaviour
{
	private float zRot = 0;
	private float smooth = 100;
    private bool canRotate;
	void Start ()
    {
        smooth = Random.Range(-smooth, smooth);
	}
	
	void Update ()
    {
        if(!canRotate) return;

        transform.rotation = Quaternion.Euler(0,0,zRot);
        zRot += Time.deltaTime * smooth;
	}

    public void SetCanRotate(bool e)
    {
        canRotate = e;
    }
}
