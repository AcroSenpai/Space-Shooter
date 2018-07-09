using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponE : MonoBehaviour
{
    public Cannon[] cannons;
    public Cartridge[] cartridge;
    public int selectedCannon;
    public int selectedCartridge;
    public Transform ammoTransform;
    public GameObject[] bulletsPrefab;

    // Use this for initialization
    void Start ()
    {
        ammoTransform = GameObject.FindGameObjectWithTag("Ammo2").GetComponent<Transform>();
        SetCannons();
        SetCartridge();

    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void SetCannons()
    {
        cannons = GetComponentsInChildren<Cannon>();
    }

    public void ShotWeapon()
    {
        cannons[selectedCannon].ShotBullet(cartridge[selectedCartridge]);
    }

    public void NextWapon()
    {
        if(selectedCannon == 0)
        {
            selectedCannon = cannons.Length -1;
        }
        else
        {
            selectedCannon--;
        }
    }

    public void PreviousWapon()
    {
        if(selectedCannon == cannons.Length - 1)
        {
            selectedCannon = 0;
        }
        else
        {
            selectedCannon++;
        }
    }

    public void NextBullet()
    {
        if(selectedCartridge == 0)
        {
            selectedCartridge = cartridge.Length - 1;
        }
        else
        {
            selectedCartridge--;
        }
    }

    public void PreviousBullet()
    {
        if(selectedCartridge == cartridge.Length - 1)
        {
            selectedCartridge = 0;
        }
        else
        {
            selectedCartridge++;
        }
    }

    public virtual void SetCartridge()
    {
        bulletsPrefab = Resources.LoadAll<GameObject>("EBullets");
        

        cartridge = new Cartridge[bulletsPrefab.Length];
        Vector3 position = ammoTransform.position;
        for(selectedCartridge = 0; selectedCartridge < cartridge.Length; selectedCartridge ++)
        {
            position += Vector3.up * 1.0F;
            GameObject obj = new GameObject();
            obj.name = "Cartridge_" + (selectedCartridge + 1);
            obj.transform.SetParent(ammoTransform);
            cartridge[selectedCartridge] = new Cartridge(2, bulletsPrefab[selectedCartridge], obj.transform, position,  "Cartridge_" + (selectedCartridge+1)+"_");
        }

        selectedCartridge = 0;
    }


    public Cartridge[] GetCartridge()
    {
        return cartridge;
    }

}
