using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReworkedEquipWep : MonoBehaviour
{
    public int EquippedWeapon;
    public int WeaponSlots = 3; // 4 slots, 0 = melee, 1 = pistol, 2 = primary1, 3 = primary2

    public 

    void Start()
    {
        EquippedWeapon = 0;
    }

    void Update()
    {
        WeaponCycle();
    }

    void WeaponCycle()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {   
            if (EquippedWeapon < 3)
            {
                EquippedWeapon += 1;
            }

            else if (EquippedWeapon == 3)
            {
                EquippedWeapon = 0;
            }
        }

        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (EquippedWeapon > 0)
            {
                EquippedWeapon -= 1;
            }

            else if (EquippedWeapon == 0)
            {
                EquippedWeapon = 3;
            }
        }
    }
}
