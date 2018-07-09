using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBoss: WeaponE
{

    public override void SetCartridge()
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
            Debug.Log(bulletsPrefab[selectedCartridge]);
            cartridge[selectedCartridge] = new Cartridge(20, bulletsPrefab[selectedCartridge], obj.transform, position,  "Cartridge_" + (selectedCartridge+1)+"_");
        }

        selectedCartridge = 0;
    }
}
