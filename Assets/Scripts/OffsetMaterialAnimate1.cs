using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetMaterialAnimate1 : MonoBehaviour
{
    private Material material;
    private Vector2 offset;
    public float smooth = -1;

    private Renderer r;
	// Use this for initialization
	void Start ()
    {
        r = GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        offset.y += Time.deltaTime * smooth;
        if(offset.y >= 10) offset.y = 0;

        MaterialPropertyBlock b = new MaterialPropertyBlock();
        r.GetPropertyBlock(b);

        b.SetVector("_MainTex_ST", new Vector4(2f, 3f, offset.x, offset.y));

        r.SetPropertyBlock(b);
	}
}
