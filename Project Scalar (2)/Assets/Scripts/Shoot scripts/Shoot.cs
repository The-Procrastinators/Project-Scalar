using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// WIP to be finished in 0.0.2 or something

public class Shoot : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject BulletPrefab;
    public bool IsShooting;
    public float WeaponSlot;
    public Animator Animator;

    float bulletForce = 50f;

    //reference scripts here
    public AmmoSys AS;
    public InvUI IU;

    void Start()
    {
        WeaponSlot = 0f;
    }

    void Update()
    {
        ClickSense();
        WeaponEquip();
    }

    void WeaponEquip()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (WeaponSlot < 3f)
            {
                WeaponSlot += 1f;
            }

            else if (WeaponSlot >= 3f)
            {
                WeaponSlot = 0f;
            }
        }

        else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (WeaponSlot > 0f)
            {
                WeaponSlot -= 1f;
            }

            else if (WeaponSlot <= 0f)
            {
                WeaponSlot = 3f;
            }
        }

        if (WeaponSlot >= 1)
        {
            Animator.SetBool("EquipPistol", true);
        }
    }

    void ClickSense()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (WeaponSlot >= 1)
            {
                Fire();
            }

        }

        else
        {
            IsShooting = false;
        }
    }


    void Fire()
    {
        if (AS.MagCount > 0f && !IU.IsOpened && !AS.IsReloading)
        {

            GameObject bullet = Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(FirePoint.up * bulletForce, ForceMode2D.Impulse);
            AS.MagCount -= 1f;
            IsShooting = true;

        }
    }
}
