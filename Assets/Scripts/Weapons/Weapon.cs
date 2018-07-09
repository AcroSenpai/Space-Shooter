using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Cannon[] cannons;
    public Cartridge[] cartridge;
    private int selectedCannon;
    private int selectedCartridge;
    public Transform ammoTransform;
    private GameObject[] bulletsPrefab;

    // Use this for initialization
    void Start ()
    {
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

    public void PreviousWapon()
    {
        if(selectedCannon == 0)
        {
            selectedCannon = 0;
        }
        else
        {
            selectedCannon--;
        }
    }

    public void NextWapon()
    {
        if(selectedCannon == cannons.Length - 1)
        {
            selectedCannon = cannons.Length - 1;
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

    public void SetCartridge()
    {
        bulletsPrefab = Resources.LoadAll<GameObject>("Bullets");
        

        cartridge = new Cartridge[bulletsPrefab.Length];
        Vector3 position = ammoTransform.position;
        for(selectedCartridge = 0; selectedCartridge < cartridge.Length; selectedCartridge ++)
        {            
            GameObject obj = new GameObject();
            obj.name = "Cartridge_" + (selectedCartridge + 1);
            obj.transform.SetParent(ammoTransform);
            obj.transform.localPosition = Vector3.zero;
            cartridge[selectedCartridge] = new Cartridge(20, bulletsPrefab[selectedCartridge], obj.transform, position,  "Cartridge_" + (selectedCartridge+1)+"_");
            position += Vector3.up * 1.0F;
        }

        selectedCartridge = 0;
    }


    public Cartridge[] GetCartridge()
    {
        return cartridge;
    }

    public int GetSelectedCannon()
    {
        return selectedCannon;
    }

    public int GetSelectedCartidge()
    {
        return selectedCartridge;
    }

}
